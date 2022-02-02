namespace YahtzeeApp
{
    public static class ScoreEngine
    {
        public static int CalculateCombination(Roll roll, Combination combination)
        {
            return combination switch
            {
                Combination.Chance => roll.GetDicesValueSum(),
                Combination.ThreeOfAKind => roll.HasThreeOfKind() ? roll.GetDicesValueSum() : 0,
                Combination.FourOfAKind => roll.HasFourOfKind() ? roll.GetDicesValueSum() : 0,
                Combination.Yahtzee => roll.HasYahtzee() ? 50 : 0,
                _ => (int)combination * roll.GetOccurencesOf((int)combination)
            };
        }
    }
}