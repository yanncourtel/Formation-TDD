using System;

namespace YahtzeeApp
{
    public class Player
    {
        private ScoreBoard scoreBoard;
        private IDiceGenerator diceGenerator;

        public Player(ScoreBoard scoreBoard, IDiceGenerator diceGenerator)
        {
            this.scoreBoard = scoreBoard;
            this.diceGenerator = diceGenerator;
        }

        public object Roll { get; set; }

        public void RollDices()
        {
            throw new NotImplementedException();
        }

        public void SelectScore(Combination ones)
        {
            throw new NotImplementedException();
        }
    }
}