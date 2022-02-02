using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace YahtzeeApp.Tests.Feature
{
    public class BonusFeatures
    {
        private Mock<IDiceGenerator> _diceGenerator;

        /*
         *
Scenario 1 : Bonus Simple Combination

Given the player selects score of 4 for combination ones
And the player selects score of 8 for combination twos
And the player selects score of 12 for combination threes
And the player selects score of 16 for combination fours
And the player selects score of 20 for combination fives
When the player selects score of 24 for combination sixes
Then the simple combination bonus is added to the total score
And the simple combination bonus score is 35
         */
        [Fact]
        public void Bonus_Simple_Combination()
        {
            // Given
            var scoreBoard = new ScoreBoard();
            _diceGenerator = new Mock<IDiceGenerator>();
            var player = new Player(scoreBoard, _diceGenerator.Object);

            SetGeneratedDices(1, 1, 1, 1, 6);
            player.RollDices();
            player.SelectScore(Combination.Ones);

            SetGeneratedDices(2, 2, 2, 2, 6);
            player.RollDices();
            player.SelectScore(Combination.Twos);

            SetGeneratedDices(3, 3, 3, 3, 6);
            player.RollDices();
            player.SelectScore(Combination.Threes);

            SetGeneratedDices(4, 4, 4, 4, 6);
            player.RollDices();
            player.SelectScore(Combination.Fours);

            SetGeneratedDices(5, 5, 5, 5, 6);
            player.RollDices();
            player.SelectScore(Combination.Fives);

            // When
            SetGeneratedDices(6, 6, 6, 6, 1);
            player.RollDices();
            player.SelectScore(Combination.Sixes);

            // Assert
            Assert.Equal(119, scoreBoard.GetTotalScore());
        }

        private void SetGeneratedDices(int v1, int v2, int v3, int v4, int v5)
        {
            _diceGenerator.Setup(x => x.GenerateDices(5))
                .Returns(new List<Dice>()
                {
                    new Dice(v1), new Dice(v2), new Dice(v3), new Dice(v4), new Dice(v5)
                });
        }
    }
}
