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
        public void Calculate_For_Combinations_Ones_With_Roll_containing_Single_One_Returns_1(int diceValue1, int diceValue2, int diceValue3, int diceValue4, int diceValue5, Combination combination, int expectedResult)
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
