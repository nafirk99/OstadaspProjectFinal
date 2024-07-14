using BookStore.App.Data;
using BookStore.App.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.App.Services
{
    public class BooksServices : IBookServices
    {
        //deklarimi i appdbcontext
        private AppDbContext _context;
        public BooksServices(AppDbContext context)
        {
            _context = context;
        }


        public string GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Book> GetAllBooks()
        {
            var allBooks = _context.Books.Include(n => n.Author).ToList();
            return allBooks;
        }

        public Book GetBookById(int id)
        {
            var newBook = _context.Books
                .FirstOrDefault(n => n.Id == id);

            return newBook;
        }

        public Book Modify(int id, Book newBook)
        {
            var result = _context.Books.FirstOrDefault(n => n.Id == id);
            result.Title = newBook.Title;
            result.AuthorId = newBook.AuthorId;
            result.NrOfPages = newBook.NrOfPages;
            result.PublishedYear = newBook.PublishedYear;
            result.URLimg = newBook.URLimg; 

            _context.Books.Update(result);
            _context.SaveChanges();
            return newBook;
        }

        public void Delete(int id)
        {
            var result = _context.Books.FirstOrDefault(n => n.Id == id);
            _context.Books.Remove(result);
            _context.SaveChanges();
        }

        

        public Book Create(Book createBook)
        {
            _context.Books.Add(createBook);
            _context.SaveChanges();
            return createBook;
        }
    }

}