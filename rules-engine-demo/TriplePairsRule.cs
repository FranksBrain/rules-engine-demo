using System.Collections.Generic;

namespace rules_engine_demo
{
    public class TriplePairsRule : IRule
    {
        private readonly int _score;
        public TriplePairsRule(int score)
        {
            _score = score;
        }

        public ScoreResult Eval(Dictionary<int, int> dieCounts)
        {
            int numberOfPairs = 0;

            var diceUsed = new Dictionary<int, int>();

            for (int i = 1; i <= 6; i++)
            {
                if (dieCounts[i] == 2)
                {
                    numberOfPairs++;
                    diceUsed.Add(i, 2);
                }
            }
            if (numberOfPairs == 3)
            {
                var scoreResult = new ScoreResult(_score, diceUsed);
                return scoreResult;
            }

            return new ScoreResult(0, new Dictionary<int, int>());
        }
    }
}