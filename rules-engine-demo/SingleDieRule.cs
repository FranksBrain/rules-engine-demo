using System.Collections.Generic;

namespace rules_engine_demo
{
    public class SingleDieRule : IRule
    {
        private readonly int _dieValue;
        private readonly int _score;

        public SingleDieRule(int dieValue, int score)
        {
            _dieValue = dieValue;
            _score = score;
        }

        public ScoreResult Eval(Dictionary<int, int> dieCounts)
        {
            var score = 0;
            score += dieCounts[_dieValue] * _score;
            var diceUsed = new Dictionary<int, int>();
            diceUsed.Add(_dieValue, 1);
            return new ScoreResult(score, diceUsed);
        }
    }
}