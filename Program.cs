namespace ArraysExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Players players = new Players();
            players.WriteAllPlayers();
            players.AddPlayer("Rokas Cvirka");
            Console.WriteLine();
            players.WriteAllPlayers();
            players.ChangePlayersNumber("Sergio Rico", 47);
            Console.WriteLine();
            players.WriteAllPlayers();
            players.DeletePlayer("Keylor Navas");
            Console.WriteLine();
            players.WriteAllPlayers();

        }
    }
}