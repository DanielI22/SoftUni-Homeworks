using System.ComponentModel.DataAnnotations;
using static Library.Common.EntityValidationConstants.Category;
namespace Library.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;
    }
}
