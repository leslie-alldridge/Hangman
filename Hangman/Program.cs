using System;
using static System.Console;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            var playGame = true;
            while (playGame)
                {
            
            WriteLine("Would you like to play a game of Hangman? y/n");

            var input = ReadLine();

            var validatedInput = Regex.IsMatch(input, "[a-zA-Z]");

            if (validatedInput && input.ToLower() == "y")
            {
                WriteLine("Genrating a word... please wait");

                var wordList = new List<string>(){ "Abacus", "Triangle", "Car", "Airline" };

                var failurePhrases = new List<string>(){
                    "Draw and upside-down L This is the post the man hangs from.",
                    "Draw a small circle for the head underneath the horizontal line of the L.",
                    "Draw a line down from the bottom of the head for the body.",
                    "Draw one arm out from the middle of his body for the arm.",
                    "Draw the other arm",
                    "Draw one diagonal line from the bottom of the body for the first leg.",
                    "Draw the other leg.",
                    "Connect the head to the post with a noose. You are dead."
                };

                var currentStatus = new List<string>();

                var failures = 0;
                var wordsRemaining = true;

                // Generate a random number to choose a word
                Random rnd = new Random();
                int index = rnd.Next(0, wordList.Count);

                var answer = wordList[index].ToLower();

                foreach (char c in answer){
                    Write("_ ");
                    currentStatus.Add("_ ");
                }

                while (failures < 8 && wordsRemaining)
                {
                    Write("\n");
                    WriteLine("Please guess a letter:");

                    var guess = ReadLine();

                    var validatedGuess = Regex.IsMatch(guess, "[a-zA-Z]");

                    if (validatedGuess && answer.Contains(guess.ToLower()))
                    {
                        WriteLine($"You guessed: {guess} correctly!");
                        while((index=answer.IndexOf(guess, index)) != -1){
                            currentStatus[index] = guess;
                                index ++;
                            }
                        WriteLine(String.Join("", currentStatus));
                    }
                    else {
                        WriteLine(failurePhrases[failures]);
                        failures ++;
                    }
                }

                if (failures == 8){
                    WriteLine("Game over, better luck next time. Type q to quit or press any key to continue.");
                } else {
                    WriteLine($"Congratulations! You guessed {answer} correctly");
                }

                var exitGame = ReadLine();
                if (exitGame.Equals('q') || exitGame.Equals('Q'))
                        {
                        playGame = false;
                    }

            
                } else {
                    WriteLine("Closing game..");
                playGame = false;}
            }
        }
    }
}
