using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._FootballTeamGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            
                List<Team> teams = new List<Team>();
                string command = Console.ReadLine();

            while (command != "END")
            {
                try
                {
                    string[] tokens = command.Split(';');

                    if (tokens[0] == "Team")
                    {
                        string teamName = tokens[1];
                        Team team = new Team(teamName);
                        teams.Add(team);
                    }
                    else if (tokens[0] == "Add")
                    {
                        string teamName = tokens[1];
                        Team team = teams.FirstOrDefault(x => x.Name == teamName);
                        if (team == null)
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }

                        string playerName = tokens[2];
                        int endurance = int.Parse(tokens[3]);
                        int sprint = int.Parse(tokens[4]);
                        int dribble = int.Parse(tokens[5]);
                        int passing = int.Parse(tokens[6]);
                        int shooting = int.Parse(tokens[7]);

                        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                        team.AddPlayer(player);
                    }
                    else if (tokens[0] == "Remove")
                    {
                        string teamName = tokens[1];
                        Team team = teams.FirstOrDefault(x => x.Name == teamName);
                        if (team == null)
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }

                        string playerName = tokens[2];

                        team.RemovePlayer(playerName);
                    }
                    else if (tokens[0] == "Rating")
                    {
                        string teamName = tokens[1];
                        Team team = teams.FirstOrDefault(x => x.Name == teamName);
                        if (team == null)
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }

                        Console.WriteLine(team);
                    }

                    command = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    command = Console.ReadLine();

                }
            }
        }
    }
}
