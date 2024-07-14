using BookStore.App.Models;

namespace BookStore.App.ViewModels
{
    public class GetBookVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string URLimg { get; set; }

        public Author Author { get; set; }

    }
}
