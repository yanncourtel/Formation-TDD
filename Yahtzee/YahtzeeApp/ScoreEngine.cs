namespace YahtzeeApp
{
    public class ScoreEngine
    {
        public ScoreEngine()
        {
        }

        public int CalculateCombination(Roll roll, Combination combination)
        {

            return (int)combination * roll.GetOccurencesOf((int)combination);
        }
    }
}