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
                return roll.GetDicesValueSum();
            if (combination == Combination.ThreeOfAKind)
                return roll.HasThreeOfKind()? roll.GetDicesValueSum() : 0;
            if (combination == Combination.FourOfAKind)
                return roll.HasFourOfKind() ? roll.GetDicesValueSum() : 0;
            return (int)combination * roll.GetOccurencesOf((int)combination);
        }
    }
}