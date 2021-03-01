namespace Hangman.Game
{
    public class InputValidator
    {
        public int ValidateInput(string input)
        {
            var isInputValid = int.TryParse(input, out int numberOfLives);

            if (isInputValid) return numberOfLives;
            else return int.MinValue;
        }
    }
}
