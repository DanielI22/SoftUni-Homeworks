using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theatre.Data.Models;

namespace Theatre.DataProcessor.ImportDto
{
    public class ImportTheatreDto
    {
        [JsonProperty("Name")]
        [Required]
        [MaxLength(30)]
        [MinLength(4)]
        public string Name { get; set; } = null!;

        [JsonProperty("NumberOfHalls")]
        [Required]
        [Range(1,10)]
        public sbyte NumberOfHalls { get; set; }

        [JsonProperty("Director")]
        [Required]
        [MaxLength(30)]
        [MinLength(4)]
        public string Director { get; set; } = null!;

        [JsonProperty("Tickets")]
        public ImportTicketDto[] Tickets { get; set; }
    }
}
