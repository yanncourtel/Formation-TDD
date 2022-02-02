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
            var scoreBoard = CreateScoreBoard();

            // Act
            var total = scoreBoard.GetTotalScore();

            // Assert
            Assert.Equal(0,total);
        }

       

        [Fact]
        public void Should_have_total_score_of_10_After_scoring_10_for_combination_fives_and_roll_2_5_3_1_5()
        {
            // Arrange
            var scoreBoard = CreateScoreBoard();

            // Act           
            scoreBoard.SaveScore(Combination.Fives, new Roll(2,5,3,1,5));
            var total = scoreBoard.GetTotalScore();

            // Assert
            Assert.Equal(10, total);         
        }

        [Fact]
        public void Should_have_total_score_of_28_After_scoring_multiple_combinations()
        {
            // Arrange
            var scoreBoard = CreateScoreBoard();

            // Act           
            scoreBoard.SaveScore(Combination.Fives, new Roll(2, 5, 3, 1, 5));
            scoreBoard.SaveScore(Combination.Chance, new Roll(2, 5, 6, 1, 4));
            var total = scoreBoard.GetTotalScore();

            // Assert
            Assert.Equal(28, total);
        }

        [Fact]
        public void Should_get_score_of_10_for_combination_fives_After_scoring_multiple_combinations()
        {
            // Arrange
            var scoreBoard = CreateScoreBoard();

            // Act           
            scoreBoard.SaveScore(Combination.Fives, new Roll(2, 5, 3, 1, 5));
            scoreBoard.SaveScore(Combination.Chance, new Roll(2, 5, 6, 1, 4));
            var score = scoreBoard.GetScore(Combination.Fives);

            // Assert
            Assert.Equal(10, score);
        }

        private ScoreBoard CreateScoreBoard()
        {
            return new ScoreBoard();
        }
    }

    public class ScoreBoard
    {
        private readonly Dictionary<Combination, int> combinationScores;

        public ScoreBoard()
        {
            combinationScores = new Dictionary<Combination, int>();
        }

        public int TotalScore { get; private set; }

        public int GetTotalScore()
        {
            return TotalScore;
        }

        public void SaveScore(Combination combination, Roll roll)
        {
            ScoreEngine scoreEngine = new ScoreEngine();
            var result = scoreEngine.CalculateCombination(roll, combination);
            combinationScores.Add(combination, result);
            TotalScore += result;
        }

        internal int GetScore(Combination combination)
        {
            return combinationScores[combination];
        }

    }
}
