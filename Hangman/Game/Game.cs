using System;
using System.Collections.Generic;
using System.Linq;

namespace Hangman
{
    public class Game : IGame
    {
        public IEnumerable<string> FailurePhrasesList => new[]
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

        public IEnumerable<string> WordList => new[]
            {"Abacus", "Triangle", "Car", "Airline", "Tree", "Population"};

        public int Guesses
        {
            get
            {
                return 0;
            }
            set
            {
                Guesses = value;
            }
        }

        public int IncorrectGuesses { get; set; }

        public int RandomNumber => new Random().Next(0, WordList.Count());
    }
}
