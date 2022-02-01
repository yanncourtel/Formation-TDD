namespace YahtzeeApp
{
    public class ScoreEngine
    {
        public ScoreEngine()
        {
        }

        public int CalculateCombination(Roll roll, Combination combination)
        {
            if (combination == Combination.Chance)
                return 19;
            return (int)combination * roll.GetOccurencesOf((int)combination);
        }
    }
}