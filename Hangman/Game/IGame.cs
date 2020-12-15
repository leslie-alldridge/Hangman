using System.Collections.Generic;

namespace Hangman
{
    public interface IGame
    {
        IEnumerable<string> FailurePhrasesList { get; set; }
        IEnumerable<string> WordList { get; set; }
        int Guesses { get; set; }
        int IncorrectGuesses { get; set; }
        int RandomNumber { get; }
    }
}
