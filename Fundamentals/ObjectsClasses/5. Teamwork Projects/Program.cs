using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Teamwork_Projects
{
    class Team
    {
        public string TeamName { get; set; }
        public string CreatorName { get; set; }
        public List<string> MembersList { get; set; } = new List<string>();

        public Team(string teamName, string creatorName)
        {
            TeamName = teamName;
            CreatorName = creatorName;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Team> teamsList = new List<Team>();
            for(int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split('-');
                string creator = commands[0];
                string teamName = commands[1];

                Team myTeam = new Team(teamName, creator);
                bool isAlreadyCreated = false;
                bool notFirstTeam = false;
                foreach (Team team in teamsList)
                {
                    if(team.TeamName == teamName)
                    {
                        Console.WriteLine($"Team {teamName} was already created!");
                        isAlreadyCreated = true;
                    }
                }
                foreach (Team team in teamsList)
                {
                    if(team.CreatorName == creator)
                    {
                        Console.WriteLine($"{creator} cannot create another team!");
                        notFirstTeam = true;
                    }
                }
                if(!isAlreadyCreated && !notFirstTeam)
                {
                    Console.WriteLine($"Team {teamName} has been created by {creator}!");
                    teamsList.Add(myTeam);
                }
            }
            string command = Console.ReadLine();
            while (command != "end of assignment")
            {
                string[] tokens = command.Split("->");
                string member = tokens[0];
                string teamName = tokens[1];

                bool teamExists = false;
                bool memberAlreadyInTeam = false;
                foreach (Team team in teamsList) 
                {
                    if(team.TeamName == teamName)
                    {
                        teamExists = true;
                    }
                }
                if(!teamExists)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }

                foreach (Team team in teamsList)
                {
                    if (team.CreatorName == member)
                    {
                        Console.WriteLine($"Member {member} cannot join team {teamName}!");
                        memberAlreadyInTeam = true;
                    }
                    else
                    {
                        foreach (string members in team.MembersList)
                        {
                            if (members == member)
                            {
                                Console.WriteLine($"Member {member} cannot join team {teamName}!");
                                memberAlreadyInTeam = true;
                            }
                        }
                    }   
                }
                if(teamExists && !memberAlreadyInTeam)
                {
                    foreach (Team team in teamsList)
                    {
                        if(team.TeamName == teamName)
                        {
                            team.MembersList.Add(member);
                        }
                    }
                }
                command = Console.ReadLine();
            }
            List<Team> teamsToDisband = new List<Team>();

            for (int i = 0; i < teamsList.Count; i++)
            {
                if(teamsList[i].MembersList.Count == 0)
                {
                    teamsToDisband.Add(teamsList[i]);
                    teamsList.RemoveAt(i--);
                }
            }

            List<Team> sortedDisband = teamsToDisband.OrderBy(team => team.TeamName).ToList();

            foreach (Team team in teamsList)
            {
                team.MembersList.Sort();
            }

            List<Team> sortedTeamsList = teamsList.OrderByDescending(team => team.MembersList.Count).ThenBy(team => team.TeamName).ToList();

            foreach (Team team in sortedTeamsList)
            {
                Console.WriteLine(team.TeamName);
                Console.WriteLine("- " + team.CreatorName);
                foreach (string member in team.MembersList)
                {
                    Console.WriteLine("-- " + member);
                }
            }
            Console.WriteLine("Teams to disband:");
            foreach (Team team in sortedDisband)
            {
                Console.WriteLine(team.TeamName);
            }
        }
    }
}
