using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysExercise
{
    public class Players
    {
        private const string PATH = @"C:\Users\rokas.cvirka\Documents\players.txt";
        private string[] players;

        public Players()
        {
            players = GetPlayers();
        }

        public string[] GetPlayers()
        {
            string[] players = File.ReadAllLines(PATH);
            return players;
        }

        public void WriteAllPlayers()
        {
            foreach (string player in players)
            {
                for (int i = 0; i < players.Length; i++)
                {
                    if (players[i] == player)
                    {
                        Console.WriteLine($"{player} has number {i}");
                    }
                }
            }
        }

        public void AddPlayer(string playersName)
        {
            CreateNewArray();
            players[players.Length -1] = playersName;
        }

        public void DeletePlayer(string playersName)
        {
            if (PlayerNotExists(playersName))
            {
                throw new ArgumentException("Player does not exist");
            }

            string[] newPlayersArray = new string[players.Length - 1];

            int newIndex = 0;
            for (int i = 0; i < players.Length; ++i)
            {
                if (!players[i].Equals(playersName))
                {
                    newPlayersArray[newIndex++] = players[i];
                }
            }
            players = newPlayersArray;
        }

        public void ChangePlayersNumber(string playersName, int newNumber)
        {
            if (PlayerNotExists(playersName))
            {
                throw new ArgumentException("Player does not exist");
            }

            int oldNumber = GetPlayersNumber(playersName);

            if (newNumber >= players.Length)
            {
                newNumber = players.Length - 1;
                Console.WriteLine($"Players maximum number can't be higher. It is set to the maximum value: {newNumber}");
            }

            if (oldNumber >= 0 && oldNumber < players.Length && newNumber >= 0)
            {
                if (oldNumber < newNumber)
                {
                    for (int i = oldNumber; i < newNumber; i++)
                    {
                        players[i] = players[i + 1];
                    }
                }
                else
                {
                    for (int i = oldNumber; i > newNumber; i--)
                    {
                        players[i] = players[i - 1];
                    }
                }
                players[newNumber] = playersName;
            }
        }

        private string[] CreateNewArray()
        {
            string[] newPlayersArray = new string[players.Length + 1];
            Array.Copy(players, newPlayersArray, players.Length);
            players = newPlayersArray;
            return players;
        }

        private bool PlayerNotExists(string playersName)
        {
            return !players.Contains(playersName);
        }

        private int GetPlayersNumber(string player)
        {
            int playersNumber = 0;
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i] == player)
                {
                    return playersNumber = i;
                }
            }
            return playersNumber;
        }
    }
}
