using System.Collections.Generic;

namespace Hangman
{
    public interface IGame
    {
        IEnumerable<string> WordList { get; set; }
        IEnumerable<string> FailurePhrasesList { get; set; }
        int LivesRemaining { get; set; }
        int Guesses { get; set; }
        int IncorrectGuesses { get; set; }
        int RandomNumber { get; }
    }
}
