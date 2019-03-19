namespace FoopMiniProject
{
    class Yatzy
    {
        public int numberOfDices = 6;
        public int[] rolledDices = new int[7];
        public void Roll()
        {
            for (var i = 0; i < numberOfDices + 1; i++)
            {
                var newDice = new Dice(6);
                newDice.Roll();
                rolledDices[i] = newDice.Current;
            }
        }
        public int Chance()
        {
            int chanceRes = 0;
            foreach(int diceValue in rolledDices)
            {
                chanceRes += rolledDices[i];
            }
            return chanceRes;
        }

        public int NumberOf(int eyes)
        {
            int numberOfDices = 0;
            foreach(int diceValue in rolledDices)
            {
                numberOfDices++;
            }
            return numberOfDices;
        }
    }
    class TestYatzy
    {
        static void Main(string[] args)
        {
            Yatzy newYatzyGame = new Yatzy();
            newYatzyGame.Roll();
            System.Console.WriteLine(newYatzyGame.rolledDices.ToString());
        }
    }
}