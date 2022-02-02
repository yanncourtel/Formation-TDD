﻿using System.Collections.Generic;
using Moq;
using Xunit;

namespace YahtzeeApp.Tests
{
    public class PlayerTests
    {
        [Fact]
        public void Should_set_roll_after_rolling_dices()
        {
            // Arrange
            var scoreBoard = new ScoreBoard();
            var diceGenerator = new Mock<IDiceGenerator>();
            var player = new Player(scoreBoard, diceGenerator.Object);

            diceGenerator.Setup(x => x.GenerateDices(5))
                .Returns(new List<Dice>()
                {
                    new Dice(1), new Dice(1), new Dice(1), new Dice(1), new Dice(1)
                });

            // Act
            player.RollDices();

            // Assert
            Assert.True(player.Roll.HasYahtzee());
        }

    }
}
