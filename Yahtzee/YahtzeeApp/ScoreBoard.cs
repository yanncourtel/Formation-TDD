using System.Collections.Generic;
using System.Linq;

namespace YahtzeeApp
{
    public class ScoreBoard
    {
        private readonly Dictionary<Combination, int> combinationScores;

        public ScoreBoard()
        {
            combinationScores = new Dictionary<Combination, int>();
        }

        public int GetTotalScore()
        {
            return combinationScores.Values.Sum();
        }

        public void SaveScore(Combination combination, Roll roll)
        {
            if (combinationScores.ContainsKey(combination))
                throw new CanNotScoreTwiceException();
            var result = ScoreEngine.CalculateCombination(roll, combination);
            combinationScores.Add(combination, result);
        }

        public int? GetScore(Combination combination)
        {
            return  combinationScores.ContainsKey(combination) ? combinationScores[combination] : null;
        }

        public int PreviewScore(Combination combination, Roll roll)
        {
            return ScoreEngine.CalculateCombination(roll, combination);
        }

        public int GetSimpleCombinationTotalScore()
        {
            return combinationScores.Where(x => (int)x.Key >= 1 && (int)x.Key <= 6).Sum(x => x.Value);
        }
    }
}