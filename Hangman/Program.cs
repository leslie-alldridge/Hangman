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

                var answer = wordList[index];

                Console.WriteLine("")


                    First wrong answer: Draw and upside-down "L." This is the post the man hangs from.
Second: Draw a small circle for the "head" underneath the horizontal line of the "L."
Third: Draw a line down from the bottom of the head for the "body."
Fourth: Draw one arm out from the middle of his body for the "arm."
Fifth: Draw the other arm.
Sixth: Draw one diagonal line from the bottom of the body for the first "leg."
Seventh: Draw the other leg.
Eighth: Connect the head to the post with a "noose." Once you draw the noose the players have lost the game.
            }
        }
    }
}
