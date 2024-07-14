﻿namespace BookStore.App.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Relationships
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
