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

        public Roll Roll { get; set; }

        public void RollDices()
        {
            Roll = new Roll(new Dice(1), new Dice(1), new Dice(1), new Dice(1), new Dice(1));
        }

        public void SelectScore(Combination ones)
        {
            throw new NotImplementedException();
        }
    }
}