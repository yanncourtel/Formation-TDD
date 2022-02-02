using System.Collections.Generic;
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
            Roll roll = new RollBuilder().FromDicesValue(2, 5, 3, 1, 5).Build();
            
            // Act           
            scoreBoard.SaveScore(Combination.Fives, roll);
            var total = scoreBoard.GetTotalScore();

            // Assert
            Assert.Equal(10, total);         
        }

        [Fact]
        public void Should_have_total_score_of_28_After_scoring_multiple_combinations()
        {
            // Arrange
            var scoreBoard = CreateScoreBoard();
            Roll roll1 = new RollBuilder().FromDicesValue(2, 5, 3, 1, 5).Build();
            Roll roll2 = new RollBuilder().FromDicesValue(2, 5, 6, 1, 4).Build();

            // Act           
            scoreBoard.SaveScore(Combination.Fives, roll1);
            scoreBoard.SaveScore(Combination.Chance, roll2);
            var total = scoreBoard.GetTotalScore();

            // Assert
            Assert.Equal(28, total);
        }

        [Fact]
        public void Should_get_score_of_10_for_combination_fives_After_scoring_multiple_combinations()
        {
            // Arrange
            var scoreBoard = CreateScoreBoard();
            Roll roll1 = new RollBuilder().FromDicesValue(2, 5, 3, 1, 5).Build();
            Roll roll2 = new RollBuilder().FromDicesValue(2, 5, 6, 1, 4).Build();

            // Act           
            scoreBoard.SaveScore(Combination.Fives, roll1);
            scoreBoard.SaveScore(Combination.Chance, roll2);
            var score = scoreBoard.GetScore(Combination.Fives);

            // Assert
            Assert.Equal(10, score);
        }

        [Fact]
        public void Should_preview_score_for_a_combination_and_a_roll()
        {
            // Arrange
            var scoreBoard = CreateScoreBoard();
            Roll roll = new RollBuilder().FromDicesValue(2, 5, 3, 1, 5).Build();
            // Act
            var score = scoreBoard.PreviewScore(Combination.Fives, roll);

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

        public int PreviewScore(Combination combination, Roll roll)
        {
            ScoreEngine scoreEngine = new ScoreEngine();
            return scoreEngine.CalculateCombination(roll, combination);
        }
    }
}
