using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Xunit;

namespace YahtzeeApp.Tests
{
    public class ScoreEngineTests
    {
        [Fact]
        public void Calculate_For_Combinations_Ones_With_Roll_containing_Single_One_Returns_1()
        {
            // Arrange
            var roll = new Roll(1, 2, 3, 4, 5);
            var scoreEngine = new ScoreEngine();


            // Act
            var result = scoreEngine.CalculateCombination(roll, "Ones");

            // Assert
            Assert.Equal(1,result);
        }
        [Fact]
        public void Calculate_For_Combinations_Ones_With_Roll_containing_No_One_Returns_0()
        {
            // Arrange
            var roll = new Roll(6, 2, 3, 4, 5);
            var scoreEngine = new ScoreEngine();

            // Act
            var result = scoreEngine.CalculateCombination(roll, "Ones");

            // Assert
            Assert.Equal(0, result);
        }
    }

    public class ScoreEngine
    {
        public ScoreEngine()
        {
        }

        public int CalculateCombination(Roll roll, string combination)
        {
            return roll.GetOccurencesOf(1);
        }
    }

    public class Roll
    {
        public Roll(int v1, int v2, int v3, int v4, int v5)
        {
        }

        public int GetOccurencesOf(int v)
        {
            return 1;
        }
    }
}
