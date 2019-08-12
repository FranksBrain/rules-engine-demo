using System.Collections.Generic;

namespace rules_engine_demo
{
    public class SetOfDiceRule : IRule
    {
        private readonly int _setSize;
        private readonly int _dieValue;
        private readonly int _score;
        public SetOfDiceRule(int setSize, int dieValue, int score)
        {
            _setSize = setSize;
            _dieValue = dieValue;
            _score = score;
        }

        public ScoreResult Eval(Dictionary<int, int> dieCounts)
        {
            if (dieCounts[_dieValue] >= _setSize)
            {
                var diceUsed = new Dictionary<int, int>();
                diceUsed.Add(_dieValue, _setSize);
                var scoreResult = new ScoreResult(_score, diceUsed);
                return scoreResult;
            }
            return new ScoreResult(0, new Dictionary<int, int>());
        }
    }
}