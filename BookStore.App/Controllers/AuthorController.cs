using AuthorStore.App.Services;
using BookStore.App.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthorStore.App.Controllers
{
    public class AuthorController : Controller
    {
        private IAuthorServices _authorServices;

        public AuthorController(IAuthorServices authorsServices) => _authorServices = authorsServices;
        public async Task<IActionResult> Index()
        {
            var allAuthors = await _authorServices.GetAllAuthorsAsync();

            return View(allAuthors);
        }

        public async Task<IActionResult> Details(int id)
        {
            var author = await _authorServices.GetAuthorByIdAsync(id);
            return View(author);
        }
        //Create
        public async Task<IActionResult> Create()
        {
            var newAuthor = new Author();
            return View(newAuthor);
        }

        [HttpPost]
        public async Task<IActionResult> CreateConfirm([Bind("Name")] Author createAuthor)
        {
            if (!ModelState.IsValid)
            {
                return View(createAuthor);
            }
            await _authorServices.CreateAsync(createAuthor);
            return RedirectToAction(nameof(Index));
        }



        //Get: Authors/Modify/1
        public async Task<IActionResult> Modify(int id)
        {
            var authorDetails = await _authorServices.GetAuthorByIdAsync(id);
            if (authorDetails == null) return View("NotFound");
            return View(authorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> ModifyConfirm(int id , [Bind("Name")] Author newauthor)
        {
            if (!ModelState.IsValid)
            {
                return View(newauthor);
            }
            await _authorServices.ModifyAsync(id, newauthor);
            return RedirectToAction(nameof(Index));
        }
        ///delete mv
        public async Task<IActionResult> Delete(int id )
        {
            var authorDetails = await _authorServices.GetAuthorByIdAsync(id);
            if (authorDetails == null) return View("NotFound");
            return View(authorDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var authorDetails= await _authorServices.GetAuthorByIdAsync(id);
            if (authorDetails == null) return View("NotFound");

            await _authorServices.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
