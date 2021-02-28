using System;

namespace Hangman.Game
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("Welcome to Hangman. Enter lives:");

            var input = Console.ReadLine();
            var isInputValid = int.TryParse(input, out int numberOfLives);

            if (isInputValid)
            {
                var game = new HangmanGame(numberOfLives);
                while (game.LivesRemaining > 0)
                {
                    Console.WriteLine("Please guess a letter:");

                    var guess = Console.ReadLine();
                    var isUnique = game.IsGuessUnique(guess);

                    if (isUnique)
                    {
                        var isCorrect = game.IsGuessCorrect(guess);

                        if (isCorrect)
                        {
                            Console.WriteLine($"You correctly guessed: {guess}");
                        }
                        else
                        {
                            game.ReduceLivesRemaining();
                            Console.WriteLine($"{guess} was not correct. {game.LivesRemaining} lives remain.");
                        }
                    }
                }
            } else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }
    }
}
