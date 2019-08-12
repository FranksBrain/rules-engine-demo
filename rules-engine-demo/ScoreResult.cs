using System.Collections.Generic;

namespace rules_engine_demo
{
    public class ScoreResult
    {
        public int Score { get; set; }
        public Dictionary<int, int> DiceUsed { get; set; }
        public ScoreResult()
        { }
        public ScoreResult(int score, Dictionary<int, int> diceUsed)
        {
            Score = score;
            DiceUsed = diceUsed;
        }
    }
}