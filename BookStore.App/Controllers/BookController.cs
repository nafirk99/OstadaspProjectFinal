using AuthorStore.App.Services;
using BookStore.App.Models;
using BookStore.App.Services;
using BookStore.App.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.App.Controllers
{
    public class BookController : Controller
    {
        private IBookServices _bookServices;
        private IAuthorServices _authorServices;

        public BookController(IBookServices booksServices, IAuthorServices authorServices)
        {
            _bookServices = booksServices;
            _authorServices = authorServices;
        }
        public IActionResult Index()
        {
            var allBooks = _bookServices.GetAllBooks();
            return View(allBooks);
        }

        public IActionResult Details(int id)
        {
            var book = _bookServices.GetBookById(id);


            return View(book);
        }
        //Create
        public IActionResult Create()
        {
            var allAuthors = _authorServices.GetAllAuthors();
            var newPostBookVM = new PostBookVM()
            {
                Authors = allAuthors
            };

            return View(newPostBookVM);
        }

        [HttpPost]
        public IActionResult CreateConfirm(PostBookVM createBook)
        {
            ModelState.Remove("Book.Author");
            if (!ModelState.IsValid)
            {
                return View(createBook);
            }
            _bookServices.Create(createBook.Book);
            return RedirectToAction(nameof(Index));
        }





        //Get: Books/Modify/1
        public IActionResult Modify(int id)
        {
            var bookDetails = _bookServices.GetBookById(id);
            if (bookDetails == null) return View("NotFound");
            return View(bookDetails);
        }

        [HttpPost]
        public IActionResult ModifyConfirm(int id , [Bind("Title,Author,PublishedYear,NrOfPages,URLimg")] Book newbook)
        {
            if (!ModelState.IsValid)
            {
                return View(newbook);
            }
            _bookServices.Modify(id, newbook);
            return RedirectToAction(nameof(Index));
        }
        ///delete mv
        public IActionResult Delete(int id )
        {
            var bookDetails =  _bookServices.GetBookById(id);
            if (bookDetails == null) return View("NotFound");
            return View(bookDetails);
        }

        [HttpPost, ActionName("Delete")]
        public  IActionResult DeleteConfirm(int id)
        {
            var bookDetails =  _bookServices.GetBookById(id);
            if (bookDetails == null) return View("NotFound");

            _bookServices.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
