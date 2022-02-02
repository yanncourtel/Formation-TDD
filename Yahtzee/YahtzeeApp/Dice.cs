using System;

namespace YahtzeeApp
{
    public class Dice
    {
        public int Value { get; set; }

        public Dice(int value)
        {
            if (value < 1 || value > 6)
            {
                throw new InvalidOperationException("Dice cannot have this value");
            }

            Value = value;
        }
    }
}