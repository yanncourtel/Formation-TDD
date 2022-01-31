using System.Collections.Generic;
using System.Linq;
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

        [Fact]
        public void Calculate_For_Combinations_Twos_With_Roll_containing_Three_Twos_Returns_6()
        {
            // Arrange
            var roll = new Roll(2, 2, 3, 6, 2);
            var scoreEngine = new ScoreEngine();

            // Act
            var result = scoreEngine.CalculateCombination(roll, "Twos");

            // Assert
            Assert.Equal(6, result);
        }

        [Fact]
        public void Calculate_For_Combinations_Sixes_With_Roll_containing_Two_Sixes_Returns_12()
        {
            // Arrange
            var roll = new Roll(6, 2, 3, 6, 5);
            var scoreEngine = new ScoreEngine();

            // Act
            var result = scoreEngine.CalculateCombination(roll, "Sixes");

            // Assert
            Assert.Equal(12, result);
        }

    }

    public class ScoreEngine
    {
        public ScoreEngine()
        {
        }

        public int CalculateCombination(Roll roll, string combination)
        {
            if (combination == "Twos")
                return 2 * roll.GetOccurencesOf(2);
            if (combination == "Sixes")
                return 6 * roll.GetOccurencesOf(6);

            return roll.GetOccurencesOf(1);
        }
    }

    public class Roll
    {
        private readonly List<int> _diceValues;

        public Roll(int diceValue1, int diceValue2, int diceValue3, int diceValue4, int diceValue5)
        {
            _diceValues = new List<int>(){diceValue1,diceValue2,diceValue3,diceValue4,diceValue5};
        }

        public int GetOccurencesOf(int diceValue)
        {
            return _diceValues.Count(x => x == diceValue);
        }
    }
}
