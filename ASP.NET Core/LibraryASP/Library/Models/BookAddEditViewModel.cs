using System.ComponentModel.DataAnnotations;
using static Library.Common.EntityValidationConstants.Book;
namespace Library.Models
{
    public class BookAddEditViewModel
    {
        [Required]
        [MinLength(TitleMinLength)]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MinLength(AuthorMinLength)]
        [MaxLength(AuthorMaxLength)]
        public string Author { get; set; } = null!;

        [Required]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string Url { get; set; } = null!;

        [Required]
        [Range(RatingMinValue, RatingMaxValue)]
        public decimal Rating { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public IEnumerable<CategoryViewModel> Categories { get; set; } = new HashSet<CategoryViewModel>();
    }
}
