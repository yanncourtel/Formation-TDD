using System;
using System.Collections.Generic;

namespace YahtzeeApp
{
    public class Player
    {
        private ScoreBoard scoreBoard;
        private IDiceGenerator diceGenerator;
        public Roll Roll { get; set; }
        public int TotalScore => scoreBoard.GetTotalScore();

        public Player(ScoreBoard scoreBoard, IDiceGenerator diceGenerator)
        {
            this.scoreBoard = scoreBoard;
            this.diceGenerator = diceGenerator;
        }

        public void RollDices()
        {
            var dices = diceGenerator.GenerateDices(5);
            Roll = new Roll(dices[0], dices[1], dices[2], dices[3], dices[4]);
        }

        public void SelectScore(Combination ones)
        {
            scoreBoard.SaveScore(ones, Roll);
        }
    }
}