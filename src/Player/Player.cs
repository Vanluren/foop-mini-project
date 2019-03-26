namespace foop_mini_project
{
    public class Player
    {
        public string Name { get; set; }
        public bool FairPlayer { get; set; }

        public Player (string playerName, bool playerPlaysFair)
        {
            Name = playerName;
            FairPlayer = playerPlaysFair;
        }
    }
}