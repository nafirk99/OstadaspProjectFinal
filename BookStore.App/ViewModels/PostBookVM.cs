using BookStore.App.Models;

namespace BookStore.App.ViewModels
{
    public class PostBookVM
    {
        public Book Book { get; set; } = new Book();
        public List<Author> Authors { get; set; } = new List<Author>();
    }
}
