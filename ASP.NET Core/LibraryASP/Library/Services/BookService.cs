using Library.Contracts;
using Library.Data;
using Library.Data.Models;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext dbContext;

        public BookService(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddBookAsync(BookAddEditViewModel model)
        {
            Book book = new Book
            {
                Title = model.Title,
                Author = model.Author,
                ImageUrl = model.Url,
                Description = model.Description,
                Rating = model.Rating,
                CategoryId = model.CategoryId
            };

            await dbContext.Books.AddAsync(book);
            await dbContext.SaveChangesAsync();
        }

        public async Task AddBookToCollectionAsync(string userId, int bookId)
        {
            bool alreadyAdded = await dbContext.IdentityUserBooks
               .AnyAsync(ub => ub.CollectorId == userId && ub.BookId == bookId);

            if (alreadyAdded == false)
            {
                var userBook = new IdentityUserBook
                {
                    CollectorId = userId,
                    BookId = bookId
                };

                await dbContext.IdentityUserBooks.AddAsync(userBook);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await dbContext.Books.FindAsync(id);

            if (book != null)
            {
                dbContext.Books.Remove(book);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task EditBookAsync(int id, BookAddEditViewModel model)
        {
            var book = await dbContext.Books.FindAsync(id);

            if (book != null)
            {
                book.Title = model.Title;
                book.Author = model.Author;
                book.ImageUrl = model.Url;
                book.Description = model.Description;
                book.CategoryId = model.CategoryId;
                book.Rating = model.Rating;

                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<BookViewModel>> GetAllBooksAsync()
        {
            return await dbContext.Books
                .Select(b => new BookViewModel
                {
                    Id = b.Id,
                    ImageUrl = b.ImageUrl,
                    Title = b.Title,
                    Author = b.Author,
                    Rating = b.Rating,
                    Category = b.Category.Name
                })
                .ToListAsync();
        }

        public async Task<BookAddEditViewModel> GetNewAddBookModelAsync()
        {
            IEnumerable<CategoryViewModel> categories = await dbContext.Categories
                .Select(c => new CategoryViewModel 
                { 
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();

            var model = new BookAddEditViewModel
            {
                Categories = categories
            };

            return model;
        }

        public async Task<BookAddEditViewModel?> GetNewEditBookModelAsync(int bookId)
        {
            var categories = await dbContext.Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();

            return await dbContext.Books
                .Where(b => b.Id == bookId)
                .Select(b => new BookAddEditViewModel
                {
                    Title = b.Title,
                    Author = b.Author,
                    Url = b.ImageUrl,
                    Description = b.Description,
                    Rating = b.Rating,
                    CategoryId = b.CategoryId,
                    Categories = categories
                }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<BookViewModel>> GetUserBooksAsync(string userId)
        {
            return await dbContext.IdentityUserBooks
              .Where(ib => ib.CollectorId == userId)
              .Select(ib => new BookViewModel
              {
                  Id = ib.BookId,
                  ImageUrl = ib.Book.ImageUrl,
                  Title = ib.Book.Title,
                  Author = ib.Book.Author,
                  Description = ib.Book.Description,
                  Category = ib.Book.Category.Name
              })
              .ToListAsync();
        }

        public async Task RemoveBookFromCollectionAsync(string userId, int bookId)
        {
            var userBook = await dbContext.IdentityUserBooks
                     .FirstOrDefaultAsync(ub => ub.CollectorId == userId && ub.BookId == bookId);

            if (userBook != null)
            {
                dbContext.IdentityUserBooks.Remove(userBook);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
