using System;
using System.Collections.Generic;

namespace Hangman
{
    public interface IGame
    {
        IEnumerable<string> FailurePhrasesList { get; }
        IEnumerable<string> WordList { get; }
        int Guesses { get; set; }
        int IncorrectGuesses { get; set; }
        int RandomNumber { get; }
    }
}