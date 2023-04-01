using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Theatre.Data.Models.Enums;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Play")]
    public class ImportPlayDto
    {
        [XmlElement("Title")]
        [Required]
        [MaxLength(50)]
        [MinLength(4)]
        public string Title { get; set; } = null!;

        [XmlElement("Duration")]
        [Required]
        public string Duration { get; set; } = null!;

        [XmlElement("Raiting")]
        [Required]
        [Range(0.00, 10.00)]
        public float Rating { get; set; }

        [XmlElement("Genre")]
        [Required]
        public string Genre { get; set; } = null!;


        [XmlElement("Description")]
        [Required]
        [MaxLength(700)]
        public string Description { get; set; } = null!;


        [XmlElement("Screenwriter")]
        [Required]
        [MaxLength(30)]
        [MinLength(4)]
        public string Screenwriter { get; set; } = null!;
    }
}
