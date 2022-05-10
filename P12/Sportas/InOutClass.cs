using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Globalization;

namespace Sportas
{
    static class InOutClass
    {
        public static PlayerConatiner ReadPlayers(string filename)
        {
            PlayerConatiner Players = new PlayerConatiner();
            string[] Lines = File.ReadAllLines(filename, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(',');
                string type = Values[0];
                string TeamName = Values[1];
                string Name = Values[2];
                string Surname = Values[3];
                DateTime birthDate = DateTime.Parse(Values[4]);
                int GamePlay = int.Parse(Values[5]);
                int Score = int.Parse(Values[6]);            
                switch (type)
                {
                    case "Basketball":
                        int Rebouds = int.Parse(Values[7]);
                        int Assist = int.Parse(Values[8]);
                        Basketball balkeball = new Basketball(TeamName, Name, Surname, birthDate, GamePlay, Score, Rebouds, Assist);
                        Players.Add(balkeball);
                        break;
                    case "Football":
                        int YellowCards = int.Parse(Values[7]);
                        Football football = new Football(TeamName, Name, Surname, birthDate, GamePlay, Score, YellowCards);
                        Players.Add(football);
                        break;
                    default:
                        break; //unknown type
                }
            }
            return Players;
        }
        public static void PrintPlayers(string label, PlayerConatiner players)
        {
            Console.WriteLine(new string('-', 72));
            Console.WriteLine("| {0,-68} |", label);
            Console.WriteLine(new string('-', 72));
            Console.WriteLine("| {0,-9} | {1,-10} | {2,-10} | {3,-10} | {4,9} | {5,6}|", "Team Name", "Name", "Surname", "Birth date", "Game play", "Score");
            Console.WriteLine(new string('-', 72));
            for (int i = 0; i < players.Count; i++)
            {
                Player player = players.Get(i);
                Console.WriteLine("| {0,-9} | {1,-10} | {2,-10} | {3,-10:yyyy-MM-dd} | {4,9} | {5,6}|", player.TeamName, player.Name, player.Surname, player.BirthDate, player.GamePlay, player.Score);
            }
            Console.WriteLine(new string('-', 72));
        }
        public static TeamRegister ReadTeams(string filename)
        {
            TeamRegister Teams = new TeamRegister();
            StreamReader read = new StreamReader(filename);
            string lines;
            while ((lines = read.ReadLine()) != null)
            {
                string[] Values = lines.Split(',');
                string TeamName = Values[0];
                string City = Values[1];
                string Coach = Values[2];
                int PlayedGame = int.Parse(Values[3]);
                Teams team = new Teams(TeamName, City, Coach, PlayedGame);
                Teams.Add(team);
            }
            return Teams;
        }
        public static void PrintTeams(TeamRegister teams)
        {
            if (teams.TeamCount() > 0)
            {
                Console.WriteLine(new string('-', 55));
                Console.WriteLine(" {0,-19} {1,-10}  {2,-10} {3,8}  ", "TeamName", "City", "Coach", "PlayedGame");
                Console.WriteLine(new string('-', 55));
                for(int i = 0; i < teams.TeamCount();i++)
                {
                    Console.WriteLine(" {0,-19} {1,-10}  {2,-10} {3,8} ", teams.GetTeam(i).TeamName, teams.GetTeam(i).City, teams.GetTeam(i).Coach, teams.GetTeam(i).PlayedGame);
                }
            }
            else
                Console.WriteLine("Sorry, the are no data in file");
            Console.WriteLine(new string('-', 55));
        }
        public static void PrintPlayers1(string label, PlayerConatiner players)
        {
            if (players.Count > 0)
            {
                Console.WriteLine(new string('-', 72));
            Console.WriteLine("| {0,-68} |", label);
            Console.WriteLine(new string('-', 72));
            Console.WriteLine("| {0,-9} | {1,-10} | {2,-10} | {3,-10} | {4,9} | {5,6}|", "Team Name", "Name", "Surname", "Birth date", "Game play", "Score");
            Console.WriteLine(new string('-', 72));
            for (int i = 0; i < players.Count; i++)
            {
                Player player = players.Get(i);
                Console.WriteLine("| {0,-9} | {1,-10} | {2,-10} | {3,-10:yyyy-MM-dd} | {4,9} | {5,6}|", player.TeamName, player.Name, player.Surname, player.BirthDate, player.GamePlay, player.Score);
            }
            }
            else
                Console.WriteLine("Sorry, we do not found any information during this filter");
            Console.WriteLine(new string('-', 72));
        }
    }
}
