using System.Collections.Generic;

namespace YahtzeeApp
{
    public interface IDiceGenerator
    {
        List<Dice> GenerateDices(int i);
    }
}