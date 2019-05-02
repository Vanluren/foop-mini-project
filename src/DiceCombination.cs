namespace foop_mini_project.src
{
    /// <summary>
    /// Dice combination.
    /// </summary>
    public class DiceCombination
    {
        public string comboName;
        public int amountOf;
        public int score;
        /// <summary>
        /// Initializes a new instance of the <see cref="T:foop_mini_project.src.DiceCombination"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="amount">Amount.</param>
        /// <param name="scoreNum">Score number.</param>
        public DiceCombination(string name, int amount, int scoreNum)
        {
            comboName = name;
            amountOf = amount;
            score = scoreNum;
        }
    }
}
