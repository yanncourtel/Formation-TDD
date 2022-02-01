using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace YahtzeeApp.Tests
{
    public class ScoreBoardTests
    {
        [Fact]
        public void Should_have_initial_total_score_of_0()
        {
            // Arrange
            var scoreBoard = new ScoreBoard();

            // Act
            var total = scoreBoard.GetTotalScore();

            // Assert
            Assert.Equal(0,total);
        }

        [Fact]
        public void test()
        {
            // Arrange
            var scoreBoard = new ScoreBoard();

            // Act
            scoreBoard.SaveScore(Combination.Fives, new Roll(2,5,3,1,5));
            var total = scoreBoard.GetTotalScore();

            // Assert
            Assert.Equal(10, total);
        }
    }

    public class ScoreBoard
    {
        public ScoreBoard()
        {
        }

        public int GetTotalScore()
        {
            return 0;
        }

        internal void SaveScore(Combination fives, Roll roll)
        {
            throw new NotImplementedException();
        }
    }
}
