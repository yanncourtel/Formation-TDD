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

        public int GetOccurencesOf(int diceValue)
        {
            return _diceValues.Count(x => x == diceValue);
        }
    }
}