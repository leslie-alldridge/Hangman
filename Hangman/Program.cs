using System;
using static System.Console;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace Hangman
{
    internal class Program
    {
        private static readonly List<string> WordList = new List<string>()
            {"Abacus", "Triangle", "Car", "Airline", "Tree", "Population"};

        private static readonly List<string> FailurePhrasesList = new List<string>()
        {
            "Draw and upside-down L This is the post the man hangs from.",
            "Draw a small circle for the head underneath the horizontal line of the L.",
            "Draw a line down from the bottom of the head for the body.",
            "Draw one arm out from the middle of his body for the arm.",
            "Draw the other arm",
            "Draw one diagonal line from the bottom of the body for the first leg.",
            "Draw the other leg.",
            "Connect the head to the post with a noose. You are dead."
        };

        private static void Main()
        {
            var playGame = true;
            // Generate a random number to choose a word
            var rnd = new Random();

            while (playGame)
            {
                WriteLine("Would you like to play a game of Hangman? y/n");

                var input = ReadKey().KeyChar.ToString();

                if (input.ToLower() == "y")
                {
                    WriteLine("Generating a word... please wait");
                }
                else
                {
                    WriteLine(" - Exiting Game..");
                    break;
                }
                
                var failures = 0;
                // Generate random number and select an answer
                var index = rnd.Next(0, WordList.Count);
                var answer = WordList[index].ToLower();
                var currentGuesses = new string[answer.Length];

                while (failures < FailurePhrasesList.Count)
                {
                    WriteLine();
                    WriteLine("Please guess a letter:");

                    var keyPress = ReadKey();
                    var guess = keyPress.KeyChar.ToString();
                    WriteLine(); // whitespace for key entry

                    var isGuessValid = Regex.IsMatch(guess, "[a-zA-Z]");
                    var isInAnswer = answer.ToCharArray();

                    if (isGuessValid && answer.Contains(guess.ToLower()))
                    {
                        WriteLine($"You guessed: {guess} correctly!");

                        for (var i = 0; i < answer.Length; i++)
                        {
                            if (isInAnswer[i].ToString() == guess)
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
                        WriteLine($"{FailurePhrasesList[failures]}");
                        WriteLine($"{FailurePhrasesList.Count - failures} lives remain");
                        failures++;
                    }
                }

                if (failures == FailurePhrasesList.Count)
                {
                    WriteLine("Game over, better luck next time. Type q to quit or press any key to continue.");
                }
                else
                {
                    WriteLine($"Congratulations! You guessed {answer} correctly. Type q to quit or press any key to continue.");
                }

                var exitGame = ReadKey();
                playGame = exitGame.KeyChar.ToString().ToLower() != 'q'.ToString();
            }
        }
    }
}

