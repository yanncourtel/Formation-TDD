using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace YahtzeeApp.Tests
{
    public class PlayerTests
    {
        [Fact]
        public void test()
        {
            // Arrange
            var scoreBoard = new ScoreBoard();
            var diceGenerator = new Mock<IDiceGenerator>();
            var player = new Player(scoreBoard, diceGenerator.Object);

            // Act
            player.RollDices();

            // Assert
            Assert.NotNull(player.Roll);
        }

    }
}
