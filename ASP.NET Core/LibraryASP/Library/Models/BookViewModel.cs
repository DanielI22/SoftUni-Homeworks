using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static Library.Common.EntityValidationConstants.Book;
namespace Library.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Author { get; set; } = null!;

        public string? Description { get; set; }

        public string ImageUrl { get; set; } = null!;

        public decimal Rating { get; set; }

        public string Category { get; set; } = null!;
    }
}
