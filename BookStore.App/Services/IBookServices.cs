using BookStore.App.Models;

namespace BookStore.App.Services
{
    public interface IBookServices
    {
        List<Models.Book> GetAllBooks();
        Models.Book GetBookById(int id);
        Models.Book Modify(int id, Book newBook);
        Models.Book Create(Book createBook);
        void Delete(int id);
        
    }
}
