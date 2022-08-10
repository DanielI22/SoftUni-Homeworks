using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Race : IRace
    {
        private string raceName;
        private int numberOfloops;

        public Race(string raceName, int numberOfLaps)
        {
            Pilots = new List<IPilot>();
            TookPlace = false;
            RaceName = raceName;
            NumberOfLaps = numberOfLaps;
        }

        public string RaceName 
        { 
            get { return raceName; }
            private set
            {
                if(string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRaceName);
                }
                raceName = value;
            }
        }

        public int NumberOfLaps 
        {
            get => numberOfloops;
            private set
            {
                if(value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidLapNumbers);
                }
                numberOfloops = value;
            }
        }

        public bool TookPlace { get; set;}

        public ICollection<IPilot> Pilots { get; }

        public void AddPilot(IPilot pilot)
        {
            Pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            StringBuilder sb = new StringBuilder();
            string tookplace = TookPlace ? "Yes" : "No";
            sb.AppendLine($"The {raceName} race has:")
                .AppendLine($"Participants: {Pilots.Count}")
                .AppendLine($"Number of laps: {NumberOfLaps}")
                .AppendLine($"Took place: {tookplace}");

            return sb.ToString().Trim();
        }
    }
}
