using System;
using static System.Console;
using System.Text.RegularExpressions;
using System.Linq;

namespace Hangman
{
    internal class Program
    {
        private static void Main()
        {
            Game game = new Game();

            while (true)
            {
                WriteLine("Would you like to play a game of Hangman? y/n");

                var input = ReadKey().KeyChar.ToString();

                if (input.ToLower() != "y")
                {
                    break;
                }

                var answer = game.WordList.ElementAt(game.RandomNumber).ToLower();
                var currentGuesses = new string[answer.Length];

                while (game.IncorrectGuesses < game.FailurePhrasesList.Count())
                {
                    WriteLine();
                    WriteLine("Please guess a letter:");

                    var keyPress = ReadKey();
                    var guess = keyPress.KeyChar.ToString();
                    WriteLine(); // whitespace for key entry

                    var isGuessValid = Regex.IsMatch(guess, "[a-zA-Z]");
                    var lettersInAnswer = answer.ToCharArray();

                    if (isGuessValid && answer.Contains(guess.ToLower()))
                    {
                        WriteLine($"You guessed: {guess} correctly!");

                        for (var i = 0; i < answer.Length; i++)
                        {
                            if (lettersInAnswer[i].ToString() == guess)
                            {
                                currentGuesses[i] = guess;
                            }
                            else if (currentGuesses[i] == null)
                            {
                                currentGuesses[i] = "_";
                            }
                        }

                        foreach (var c in currentGuesses)
                        {
                            Write(c);
                        }

                        if (!currentGuesses.Contains("_"))
                        {
                            break;
                        }
                    }
                    else
                    {
                        WriteLine($"{game.FailurePhrasesList.ElementAt(game.IncorrectGuesses)}");
                        game.IncorrectGuesses++;
                        WriteLine($"{game.FailurePhrasesList.Count() - game.IncorrectGuesses} lives remain");
                    }
                }

                if (game.IncorrectGuesses == game.FailurePhrasesList.Count())
                {
                    WriteLine($"The correct answer was: {answer}.");
                    WriteLine("Game over, better luck next time. Type q to quit or press any key to continue.");
                }
                else
                {
                    WriteLine($"Congratulations! You guessed {answer} correctly. Type q to quit or press any key to continue.");
                }

                var exitGame = ReadKey();

                if (exitGame.Key == ConsoleKey.Q)
                {
                    break;
                }
            }
        }
    }
}

