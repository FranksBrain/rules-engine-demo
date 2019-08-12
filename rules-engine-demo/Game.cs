using System.Collections.Generic;
using System.Linq;

namespace rules_engine_demo
{
    public class Game
    {
        private Dictionary<int, int> _dieCounts = new Dictionary<int, int>();
        private List<IRule> _rules = new List<IRule>();

        private void PopulateDieCounts(int[] dieValues)
        {
            for (int i = 1; i <= 6; i++)
            {
                _dieCounts.Add(i, dieValues.Count(d => d == i));
            }
        }

        private void AddRules()
        {
            _rules.Add(new SingleDieRule(1, 100));
            _rules.Add(new SingleDieRule(5, 50));
            _rules.Add(new SetOfDiceRule(3, 1, 1000));
            _rules.Add(new SetOfDiceRule(4, 1, 2000));
            for (int i = 2; i < 7; i++)
            {
                _rules.Add(new SetOfDiceRule(3, i, i * 100));
                _rules.Add(new SetOfDiceRule(4, i, i * 200));
                _rules.Add(new SetOfDiceRule(5, i, i * 400));
                _rules.Add(new SetOfDiceRule(6, i, i * 800));
            }
            _rules.Add(new SetOfDiceRule(5, 1, 4000));
            _rules.Add(new SetOfDiceRule(6, 1, 8000));
            _rules.Add(new TriplePairsRule(1800));
            _rules.Add(new StraightRule(1200));
        }

        public int CalculateScore(params int[] dieValues)
        {
            if (dieValues.Length > 6 || dieValues.Length < 1)
                throw new System.Exception("You may only throw between 1 and 6 dice.");
            var score = 0;
            PopulateDieCounts(dieValues);
            AddRules();

            while (_dieCounts.Any(x => x.Value > 0))
            {
                ScoreResult bestResult = new ScoreResult();
                foreach (var rule in _rules)
                {
                    ScoreResult scoreResult = rule.Eval(_dieCounts);
                    if (scoreResult.Score > bestResult.Score)
                    {
                        bestResult = scoreResult;
                    }
                }

                score += bestResult.Score;

                if (bestResult.DiceUsed == null)
                {
                    return score;
                }

                foreach (var dieUsed in bestResult.DiceUsed)
                {
                    _dieCounts[dieUsed.Key] -= dieUsed.Value;
                }

            }

            return score;
        }
    }
}