using System.ComponentModel.DataAnnotations;
using static Library.Common.EntityValidationConstants.Category;

namespace Library.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; } = new HashSet<Book>();

    }
}