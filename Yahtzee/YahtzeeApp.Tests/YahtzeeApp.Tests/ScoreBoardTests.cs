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

        [Fact]
        public void Should_get_null_score_for_unsaved_combination()
        {
            // Arrange
            var scoreBoard = CreateScoreBoard();

            // Act           
            int? score = scoreBoard.GetScore(Combination.Fives);

            // Assert
            Assert.Null(score);
        }

        [Fact]
        public void Should_not_score_twice_for_same_combination()
        {
            // Arrange
            var scoreBoard = CreateScoreBoard(); ;
            Roll roll = new RollBuilder().FromDicesValue(2, 5, 3, 1, 5).Build();

            // Act

            scoreBoard.SaveScore(Combination.Fives, roll);
            // Assert
            Assert.Throws<CanNotScoreTwiceException>(() =>
                scoreBoard.SaveScore(Combination.Fives, roll));
        }

        [Fact]
        public void Should_get_total_score_for_simple_combination()
        {
            // Arrange
            var scoreBoard = CreateScoreBoard();
            Roll roll1 = new RollBuilder().FromDicesValue(2, 5, 3, 1, 5).Build();
            Roll roll2 = new RollBuilder().FromDicesValue(2, 2, 3, 1, 5).Build();
            scoreBoard.SaveScore(Combination.Chance, roll2);
            scoreBoard.SaveScore(Combination.Fives, roll1);

            // Act         

            var total = scoreBoard.GetSimpleCombinationTotalScore();

            // Assert
            Assert.Equal(10, total);
        }
        private ScoreBoard CreateScoreBoard()
        {
            return new ScoreBoard();
        }
    }
}
