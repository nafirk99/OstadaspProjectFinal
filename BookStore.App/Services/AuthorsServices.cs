using BookStore.App.Data;
using BookStore.App.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorStore.App.Services
{
    public interface IAuthorServices
    {
        Task<List<Author>> GetAllAuthorsAsync();
        Task<Author> GetAuthorByIdAsync(int id);
        Task<Author> ModifyAsync(int id, Author newAuthor);
        Task<Author> CreateAsync(Author createAuthor);
        Task DeleteAsync(int id);
    }

    public class AuthorsServices : IAuthorServices
    {
        //deklarimi i appdbcontext
        private AppDbContext _context;
        public AuthorsServices(AppDbContext context)
        {
            _context = context;
        }


        public async Task<List<Author>> GetAllAuthorsAsync()
        {
            var allAuthors = await _context.Authors.Include(n => n.Books).ToListAsync();
            return allAuthors;
        }
        

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Authors.FirstOrDefaultAsync(n => n.Id == id);
            _context.Authors.Remove(result);
            await _context.SaveChangesAsync();
        }

       
        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            var newAuthor = await _context.Authors
                .FirstOrDefaultAsync(n => n.Id == id);

            return newAuthor;
        }

        public async Task<Author> ModifyAsync(int id, Author newAuthor)
        {
            var result = await _context.Authors.FirstOrDefaultAsync(n => n.Id == id);
            result.Name = newAuthor.Name;
            //result.Author = newBook.Author;
            //result.NrOfPages = newBook.NrOfPages;
            //result.PublishedYear = newBook.PublishedYear;
            //result.URLimg = newBook.URLimg; 

            _context.Authors.Update(result);
            await _context.SaveChangesAsync();
            return newAuthor;
        }

        public async Task<Author> CreateAsync(Author createAuthor)
        {
            await _context.Authors.AddAsync(createAuthor);
            await _context.SaveChangesAsync();
            return createAuthor;
        }
    }

}