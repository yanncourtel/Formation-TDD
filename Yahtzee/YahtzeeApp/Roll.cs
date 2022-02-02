using System;
using System.Collections.Generic;
using System.Linq;

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

    public class Roll
    {
        private readonly List<int> _diceValues;

        public Roll(Dice diceValue1, Dice diceValue2, Dice diceValue3, Dice diceValue4, Dice diceValue5)
        {
            _diceValues = new List<int>() { diceValue1.Value, diceValue2.Value, diceValue3.Value, diceValue4.Value, diceValue5.Value };
        }

        internal bool HasThreeOfKind()
        {
            return HasNumberOfOccurence(3);
        }

        internal bool HasFourOfKind()
        {
            return HasNumberOfOccurence(4);
        }

        private bool HasNumberOfOccurence(int n)
        {
            return _diceValues.GroupBy(dice => dice).Any(x => x.Count() == n);
        }

        public int GetDicesValueSum()
        {
            return  _diceValues.Sum();
        }

        public int GetOccurencesOf(int diceValue)
        {
            return _diceValues.Count(x => x == diceValue);
        }

        public bool HasYahtzee()
        {
            return _diceValues.Distinct().Count() == 1;
        }
    }
}