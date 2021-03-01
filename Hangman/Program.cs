using System;

namespace Hangman.Game
{
    public class Program
    {
        public static void Main()
        {
            while (true)
            {

                Console.WriteLine("Welcome to Hangman. Enter lives or type q to quit:");

                var input = Console.ReadLine();

                if (input == "q")
                {
                    // User has requested to quit the game
                    break;
                }

                var validator = new InputValidator();
                var numberOfLives = validator.ValidateInput(input);

                var game = new HangmanGame(numberOfLives);

                if (numberOfLives > 0)
                {


                    while (game.LivesRemaining > 0)
                    {
                        if (game.IsGameWon())
                        {
                            Console.WriteLine($"\nYou have guessed {game.Answer} correctly!");

                            break;
                        }

                        Console.WriteLine("\nPlease guess a letter:");

                        var guess = Console.ReadKey().KeyChar.ToString();
                        var isUnique = game.IsGuessUnique(guess);

                        if (isUnique)
                        {
                            var isCorrect = game.IsGuessCorrect(guess);

                            if (isCorrect)
                            {
                                Console.WriteLine($"\nYou correctly guessed: {guess}");
                                game.PrintGameState();
                            }
                            else
                            {
                                game.ReduceLivesRemaining();

                                // Has the player run out of lives?
                                if (game.LivesRemaining == 0)
                                {
                                    Console.WriteLine($"\nYou've run out of lives. The answer was: {game.Answer}.");

                                    break;
                                }
                                else
                                {
                                    Console.WriteLine($"\n{guess} was not correct. {game.LivesRemaining} lives remain.");
                                    game.PrintGameState();
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
