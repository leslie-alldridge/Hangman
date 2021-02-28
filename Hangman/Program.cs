using System;

namespace Hangman.Game
{
    public static class Program
    {
        public static void Main()
        {
            while (true)
            {

                Console.WriteLine("Welcome to Hangman. Enter lives or type q to quit:");

                var input = Console.ReadLine();

                if (input == "q")
                {
                    // User wants to quit the game
                    break;
                }

                var isInputValid = int.TryParse(input, out int numberOfLives);

                if (isInputValid)
                {
                    var game = new HangmanGame(numberOfLives);

                    while (game.LivesRemaining > 0)
                    {
                        // Has the player won the game?
                        if (game.GenerateGameState() == game.Answer)
                        {
                            Console.WriteLine($"You have guessed {game.Answer} correctly!");

                            break;
                        }

                        Console.WriteLine("Please guess a letter:");

                        var guess = Console.ReadKey().KeyChar.ToString();
                        var isUnique = game.IsGuessUnique(guess);

                        if (isUnique)
                        {
                            var isCorrect = game.IsGuessCorrect(guess);

                            if (isCorrect)
                            {
                                Console.WriteLine($"\nYou correctly guessed: {guess}");

                                game.GenerateGameState();
                            }
                            else
                            {
                                game.ReduceLivesRemaining();

                                // Has the player run out of lives?
                                if (game.LivesRemaining == 0)
                                {
                                    Console.WriteLine($"You've run out of lives. The answer was: {game.Answer}.");

                                    break;
                                }
                                else
                                {
                                    Console.WriteLine($"\n{guess} was not correct. {game.LivesRemaining} lives remain.");
                                    game.GenerateGameState();
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }

            Console.WriteLine("Closing game...");
        }
    }
}
