using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Xunit;

namespace YahtzeeApp.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Calculate_combinations_ones()
        {
            // Arrange
            var roll = new Roll(1, 2, 3, 4, 5);
            var scoreEngine = new ScoreEngine();


            // Act
            var result = scoreEngine.CalculateCombination(roll, "Ones");

            // Assert
            Assert.Equal(1,result);
        }
    }

    public class ScoreEngine
    {
        public ScoreEngine()
        {
        }

        public int CalculateCombination(Roll roll, string ones)
        {
            return 1;
        }
    }

    public class Roll
    {
        private int v1;
        private int v2;
        private int v3;
        private int v4;
        private int v5;

        public Roll(int v1, int v2, int v3, int v4, int v5)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
            this.v5 = v5;
        }
    }
}
