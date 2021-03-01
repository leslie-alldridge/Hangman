using Xunit;
using Hangman.Game;

namespace Hangman.UnitTests.Validator
{
    public class ValidatorTests
    {
        private InputValidator Validator => new InputValidator();

        [Fact]
        public void Integers_are_a_valid_input()
        {
            var result = Validator.ValidateInput("4");

            Assert.Equal(4, result);
        }

        [Fact]
        public void Unable_to_set_a_non_numeric_number_of_lives()
        {
            var result = Validator.ValidateInput("ten lives please");

            Assert.Equal(int.MinValue, result);
        }
    }
}
