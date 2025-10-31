using System;

namespace Task13_StructsEnums
{
    public enum Genre
    {
        Fiction,
        NonFiction,
        SciFi,
        Biography,
        Mystery,
        Romance
    }

    public struct Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public Genre Category { get; set; } // using the enum to represent book genre

        public Book(string title, string author, Genre category)
        {
            Title = title;
            Author = author;
            Category = category;
        }
        public void Display()
        {
            Console.WriteLine($"\"{Title}\" by {Author} [{Category}]");
        }
    }
}