using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman.Game
{
    public class HangmanGame
    {
        public string[] WordList { get; }
        public string[] FailurePhrasesList { get; }
        public int LivesRemaining { get; set; }
        public string Answer { get; set; }

        public List<string> Guesses { get; set; }

        public HangmanGame(int numberOfLives)
        {
            WordList = new[] { "Abacus", "Triangle", "Car", "Airline", "Tree", "Population" };

            FailurePhrasesList = new[]
            {
                "Draw an upside-down L This is the post the man hangs from.",
                "Draw a small circle for the head underneath the horizontal line of the L.",
                "Draw a line down from the bottom of the head for the body.",
                "Draw one arm out from the middle of his body for the arm.",
                "Draw the other arm",
                "Draw one diagonal line from the bottom of the body for the first leg.",
                "Draw the other leg.",
                "Connect the head to the post with a noose. You are dead."
            };

            LivesRemaining = numberOfLives;

            Answer = WordList[new Random().Next(5)].ToLower();

            Guesses = new List<string>();

        }

        internal string GenerateGameState()
        {
            var builder = new StringBuilder();

            foreach (char c in Answer)
            {
                if (Guesses.Contains(c.ToString()))
                {
                    builder.Append(c);
                }
                else
                {
                    builder.Append("_ ");
                }
            }

            Console.WriteLine($"\n{builder}");
            return builder.ToString();
        } // this can go into the method below...

        public bool IsGuessCorrect(string guess)
        {
            if (Answer.Contains(guess))
            {
                Guesses.Add(guess.ToLower());
                return true;
            }

            return false;
        }

        public bool IsGuessUnique(string guess)
        {
            return !Guesses.Contains(guess);
        }

        public void ReduceLivesRemaining()
        {
            LivesRemaining -= 1;
        }
    }
}
