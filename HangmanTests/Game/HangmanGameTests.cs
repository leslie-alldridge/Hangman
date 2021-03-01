using Hangman.Game;
using Xunit;
using System;
using System.IO;

namespace Hangman.UnitTests.Game
{
    public class HangmanGameTests
    {
        private const int DefaultNumberOfLives = 4;
        private HangmanGame DefaultGame => new HangmanGame(DefaultNumberOfLives);

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(8)]
        public void Game_starts_given_a_number_of_lives(int numberOfLives)
        {
            var game = new HangmanGame(numberOfLives);

            Assert.Equal(numberOfLives, game.LivesRemaining);
            Assert.True(game.Answer.Length > 0);
        }

        [Fact]
        public void Game_contains_word_list()
        {
            Assert.NotNull(DefaultGame.WordList);
        }

        [Fact]
        public void Can_evaluate_a_correct_guess()
        {
            var result = GenerateTestGame(DefaultNumberOfLives, "Cooktop");
            var isCorrect = result.IsGuessCorrect("o");

            Assert.True(isCorrect);
            Assert.NotEmpty(result.AllGuesses);
            Assert.Contains("o", result.CorrectGuesses.ToString());
        }

        [Fact]
        public void Can_evaluate_an_incorrect_guess()
        {
            var result = GenerateTestGame(DefaultNumberOfLives, "Bad");
            var isCorrect = result.IsGuessCorrect("o");

            Assert.False(isCorrect);
            Assert.Contains("o", result.AllGuesses);
            Assert.Equal(string.Empty, result.CorrectGuesses.ToString());
        }

        [Fact]
        public void Returns_null_when_invalid_guess()
        {
            var result = GenerateTestGame(DefaultNumberOfLives, "Bad");
            var guess = result.IsGuessCorrect("Boil");

            Assert.False(guess);
            Assert.Equal(string.Empty, result.CorrectGuesses.ToString());
        }

        [Fact]
        public void Players_can_only_guess_each_letter_once()
        {
            var result = GenerateTestGame(DefaultNumberOfLives, "Bad");

            var isValidGuess = result.IsGuessUnique("a");
            result.IsGuessCorrect("a");
            
            Assert.True(isValidGuess);

            result.IsGuessCorrect("a");
            isValidGuess = result.IsGuessUnique("a");
            
            Assert.False(isValidGuess);
            Assert.Contains(result.CorrectGuesses[0], "a");
        }

        [Fact]
        public void Incorrect_guess_reduces_lives_remaining()
        {
            var result = GenerateTestGame(DefaultNumberOfLives, "Bad");

            result.ReduceLivesRemaining();
            Assert.Equal(3, result.LivesRemaining);
        }

        [Fact]
        public void Game_state_prints_to_console()
        {
            var result = GenerateTestGame(DefaultNumberOfLives, "cooktop");
            result.IsGuessCorrect("o");

            var output = new StringWriter();
            Console.SetOut(output);

            result.PrintGameState();

            Assert.Contains("_ oo_ _ o_",output.ToString());

            result.IsGuessCorrect("c");
            result.IsGuessCorrect("k");

            result.PrintGameState();

            Assert.Contains("cook_ o_", output.ToString());
        }

        private HangmanGame GenerateTestGame(int numberOfLives, string answer)
        {
            var game = new HangmanGame(numberOfLives)
            {
                Answer = answer
            };

            return game;
        }
    }
}