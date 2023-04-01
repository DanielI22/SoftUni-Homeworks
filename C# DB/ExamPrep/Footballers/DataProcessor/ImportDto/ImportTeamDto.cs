using Footballers.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Footballers.DataProcessor.ImportDto
{
    public class ImportTeamDto
    {
        [JsonProperty("Name")]
        [Required]
        [MaxLength(40)]
        [MinLength(3)]
        public string Name { get; set; } = null!;

        [JsonProperty("Nationality")]
        [Required]
        [MaxLength(40)]
        [MinLength(2)]
        [RegularExpression("[a-zA-Z0-9 .-]+")]
        public string Nationality { get; set; } = null!;

        [JsonProperty("Trophies")]
        [Required]
        public int Trophies { get; set; }

        [JsonProperty("Footballers")]
        public int[] FootballerIds { get; set; }
    }
}
