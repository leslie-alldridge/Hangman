using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman.Game
{
    public class HangmanGame
    {
        public string[] WordList { get; }
        public string[] FailurePhrasesList { get; }
        public int LivesRemaining { get; set; }
        public string Answer { get; set; }
        public StringBuilder CorrectGuesses { get; set; }
        public List<string> AllGuesses { get; private set; }

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

            CorrectGuesses = new StringBuilder();

            AllGuesses = new List<string>();
        }

        internal void UpdateGuess(string guess)
        {
            foreach (char c in Answer)
            {
                if (c.ToString() == guess)
                {
                    CorrectGuesses.Append(guess);
                }
            }
        }

        public bool IsGameWon()
        {
            var guessedSet = new HashSet<char>(CorrectGuesses.ToString());
            var answerSet = new HashSet<char>(Answer);

            return answerSet.SetEquals(guessedSet);
        }

        public bool IsGuessCorrect(string guess)
        {
            // Keep track of all guesses so we can block duplicates in IsGuessUnique
            if (!AllGuesses.Contains(guess)) AllGuesses.Add(guess);

            if (Answer.Contains(guess))
            {
                UpdateGuess(guess.ToLower());
                return true;
            }

            return false;
        }

        public bool IsGuessUnique(string guess)
        {
            return !AllGuesses.Contains(guess);
        }

        public void ReduceLivesRemaining()
        {
            LivesRemaining -= 1;
        }

        public void PrintGameState()
        {
            var builder = new StringBuilder();

            foreach (char c in Answer)
            {
                if (CorrectGuesses.ToString().Contains(c.ToString()))
                {
                    builder.Append($"{c}");
                }
                else
                {
                    builder.Append("_ ");
                }
            }

            Console.WriteLine(builder);
        }
    }
}
