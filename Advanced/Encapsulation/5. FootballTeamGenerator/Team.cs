using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _5._FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players = new List<Player>();

        public Team(string name)
        {
            Name = name;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }

        public IReadOnlyCollection<Player> Players { get { return players.AsReadOnly(); } }

        public int Rating { get; private set; }


        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player player = players.FirstOrDefault(x => x.Name == playerName);
            if(player == null)
            {
                throw new ArgumentException($"Player {playerName} is not in {Name} team.");
            }
            players.Remove(player);
        }

        private double getRating()
        {
            if(players.Count == 0)
            {
                return 0;
            }
            double sumRating = 0;
            foreach (var player in Players)
            {
                sumRating += player.SkillLevel;
            }

            return Math.Round(sumRating / players.Count);
        }

        public override string ToString()
        {
            return $"{Name} - {getRating()}";
        }
    }
}
