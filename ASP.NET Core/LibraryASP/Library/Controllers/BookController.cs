using Library.Contracts;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class BookController : BaseController
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }
        public async Task<IActionResult> All()
        {
            IEnumerable<BookViewModel> model = await bookService.GetAllBooksAsync();
            return View(model);
        }

        public async Task<IActionResult> Mine()
        {
            IEnumerable<BookViewModel> model = await bookService.GetUserBooksAsync(GetUserId());
            return View(model);
        }

        public async Task<IActionResult> AddToCollection(int Id)
        {
            var userId = GetUserId();
            await bookService.AddBookToCollectionAsync(userId, Id);

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> RemoveFromCollection(int Id)
        {
            var userId = GetUserId();
            await bookService.RemoveBookFromCollectionAsync(userId, Id);

            return RedirectToAction(nameof(Mine));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            BookAddEditViewModel model = await bookService.GetNewAddBookModelAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookAddEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                await bookService.AddBookAsync(model);

                return RedirectToAction(nameof(All));
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            BookAddEditViewModel? model = await bookService.GetNewEditBookModelAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, BookAddEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                await bookService.EditBookAsync(id, model);

                return RedirectToAction(nameof(All));
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await bookService.DeleteBookAsync(id);

            return RedirectToAction(nameof(All));
        }
    }
}
