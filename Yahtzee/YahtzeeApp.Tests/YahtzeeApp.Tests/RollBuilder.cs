using System;

namespace YahtzeeApp.Tests
{
    public class RollBuilder
    {
        private int _value1;
        private int _value2;
        private int _value3;
        private int _value4;
        private int _value5;

        public RollBuilder()
        {
        }

        public RollBuilder FromDicesValue(int diceValue1, int diceValue2, int diceValue3, int diceValue4, int diceValue5)
        {
            this._value1 = diceValue1;
            this._value2 = diceValue2;
            this._value3 = diceValue3; 
            this._value4 = diceValue4;
            this._value5 = diceValue5;
            return this;
        }

        public Roll Build()
        {
            return new Roll(new Dice(_value1), new Dice(_value2), new Dice(_value3), new Dice(_value4), new Dice(_value5));
        }
    }
}