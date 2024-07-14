using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.App.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage ="Title is required")]
        public string Title { get; set; }


        [Display(Name = "PublshedYear")]
        [Required(ErrorMessage = "Published Year is required")]
        public int PublishedYear { get; set; }

        [Display(Name = "NrOfPages")]
        [Required(ErrorMessage = "Number of pages is required")]
        public int NrOfPages { get; set; }


        [Display(Name = "URLimg")]
        [Required(ErrorMessage = "URLimg of pages is required")]
        public string  URLimg{ get; set; }


        //Relationships
        public int AuthorId { get; set; }
        public Author Author { get; set; }

    }
}
