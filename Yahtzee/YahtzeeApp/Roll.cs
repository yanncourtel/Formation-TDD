using System;
using System.Collections.Generic;
using System.Linq;

namespace YahtzeeApp
{
    public class Roll
    {
        private readonly List<int> _diceValues;

        public Roll(int diceValue1, int diceValue2, int diceValue3, int diceValue4, int diceValue5)
        {
            _diceValues = new List<int>() { diceValue1, diceValue2, diceValue3, diceValue4, diceValue5 };
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