using System.Collections.Generic;
using System.Linq;

namespace rules_engine_demo
{
    public class StraightRule : IRule
    {
        private readonly int _score;

        public StraightRule(int score)
        {
            _score = score;
        }
        public ScoreResult Eval(Dictionary<int, int> dieCounts)
        {
            var diceUsed = new Dictionary<int, int>();

            if (dieCounts.All(x => x.Value == 1))
            {
                foreach (var dieValue in dieCounts.Keys.ToList())
                {
                    diceUsed.Add(dieValue, 1);
                }
                return new ScoreResult(_score, diceUsed);
            }
            return new ScoreResult(0, new Dictionary<int, int>());
        }
    }
}