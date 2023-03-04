using System;

namespace NK_Library.Dto
{
    internal class Book
    {
        public Book(string author, string name, string genre,  bool adultOnly, int yearOfPublication)
        {
            Author = author;
            Name = name;
            Genre = genre;
            AdultOnly = adultOnly;
            YearOfPublication = yearOfPublication;  
        }

        public string Author { get; }

        public string Name { get; }

        public string Genre { get; }

        public bool AdultOnly { get; }

        public int YearOfPublication { get; }

        public bool InfoEquals(Book book)
        {   
            if (book == null)
            {
                return false;            
            }

            return
                book.Author.Equals(Author) &&
                book.Name.Equals(Name) &&
                book.Genre.Equals(Genre) &&
                book.AdultOnly.Equals(AdultOnly) &&
                book.YearOfPublication.Equals(YearOfPublication);
        }
    }

}
