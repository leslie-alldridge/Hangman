using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Would you like to play a game of Hangman? y/n");

            var input = Console.ReadLine();

            var validatedInput = Regex.IsMatch(input, "[a-zA-Z]");

            if (validatedInput && input.ToLower() == "y")
            {
                Console.WriteLine("Genrating a word... please wait");

                var wordList = new List<string>(){ "Abacus", "Triangle", "Car", "Airline" };

                // Generate a random number to choose a word
                Random rnd = new Random();
                int index = rnd.Next(0, wordList.Count);

                var answer = wordList[index].ToLower();

                foreach (char c in answer){
                    Console.Write("_ ");
                }

                Console.Write("\n");
                Console.WriteLine("Please guess a letter:");
                var guess = Console.ReadLine();

                var validatedGuess = Regex.IsMatch(guess, "[a-zA-Z]");

                if (validatedGuess && answer.Contains(guess.ToLower()))
                {
                    Console.WriteLine($"you guessed {guess} correctly");
                }
                else {
                    Console.WriteLine("Incorrect... A post has been erected in the shape of an upside down L.");
                }


                 /*   First wrong answer: Draw and upside-down "L." This is the post the man hangs from.
Second: Draw a small circle for the "head" underneath the horizontal line of the "L."
Third: Draw a line down from the bottom of the head for the "body."
Fourth: Draw one arm out from the middle of his body for the "arm."
Fifth: Draw the other arm.
Sixth: Draw one diagonal line from the bottom of the body for the first "leg."
Seventh: Draw the other leg.
Eighth: Connect the head to the post with a "noose." Once you draw the noose the players have lost the game. */
            }
        }
    }
}
