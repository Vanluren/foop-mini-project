namespace foop_mini_project.src
{
    /// <summary>
    /// Score-class that represent the scores in the scoreboard.
    /// </summary>
    public class Score
    {
        public string scoreName;
        public int score;
        /// <summary>
        /// Initializes a new instance of the <see cref="T:foop_mini_project.src.Score"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="scoreNum">Score number.</param>
        public Score(string name = "Striken", int scoreNum = 0)
        {
            scoreName = name;
            score = scoreNum;
        }
    }
}
