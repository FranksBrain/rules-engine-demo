using System.Collections.Generic;

namespace rules_engine_demo
{
    public interface IRule
    {
        ScoreResult Eval(Dictionary<int, int> dieCounts);
    }
}