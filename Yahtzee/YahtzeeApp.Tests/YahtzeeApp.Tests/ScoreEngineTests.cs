using Xunit;

namespace YahtzeeApp.Tests
{
    public class ScoreEngineTests
    {
        [Theory]
        [InlineData(1, 2, 3, 4, 5, Combination.Ones, 1)]
        [InlineData(6, 2, 3, 4, 5, Combination.Ones, 0)]
        [InlineData(2, 2, 3, 6, 2, Combination.Twos, 6)]
        [InlineData(6, 2, 3, 6, 2, Combination.Threes, 3)]
        [InlineData(6, 2, 4, 6, 2, Combination.Fours, 4)]
        [InlineData(6, 5, 5, 5, 5, Combination.Fives, 20)]
        [InlineData(6, 2, 3, 6, 2, Combination.Sixes, 12)]
        [InlineData(6, 2, 3, 6, 2, Combination.Chance, 19)]
        [InlineData(6, 2, 6, 6, 2, Combination.ThreeOfAKind, 22)]
        [InlineData(3, 2, 6, 6, 2, Combination.ThreeOfAKind, 0)]
        public void Should_calculate_the_correct_score_for_a_roll_and_a_combination(int diceValue1, int diceValue2, int diceValue3, int diceValue4, int diceValue5, Combination combination, int expectedResult)
        {
            // Arrange
            var roll = new Roll(diceValue1, diceValue2, diceValue3, diceValue4, diceValue5);
            var scoreEngine = new ScoreEngine();

            // Act
            var result = scoreEngine.CalculateCombination(roll, combination);

            // Assert
            Assert.Equal(expectedResult, result);
        }

    }
}
