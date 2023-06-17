using Library.Models;
using System.Collections;

namespace Library.Contracts
{
    public interface IBookService
    {
        Task AddBookAsync(BookAddEditViewModel model);
        Task AddBookToCollectionAsync(string userId, int bookId);
        Task DeleteBookAsync(int id);
        Task EditBookAsync(int id, BookAddEditViewModel model);
        Task<IEnumerable<BookViewModel>> GetAllBooksAsync();
        Task<BookAddEditViewModel> GetNewAddBookModelAsync();
        Task<BookAddEditViewModel?> GetNewEditBookModelAsync(int bookId);
        Task<IEnumerable<BookViewModel>> GetUserBooksAsync(string userId);
        Task RemoveBookFromCollectionAsync(string userId, int bookId);
    }
}
