using System;

namespace NK_Library.Dto
{
    internal class Book
    {
        public Book(string author, string name, string genre, bool adultOnly)
        {
            Author = author;
            Name = name;
            Genre = genre;
            AdultOnly = adultOnly;
        }

        public string Author { get; }
        public string Name { get; }
        public string Genre { get; }
        public bool AdultOnly { get; }

        #region Equals

        public static bool operator == (Book book1, Book book2)
        {
            if ( Object.Equals(book1, null) || Object.Equals(book2, null))
            {
                return false;
            }

            return book1.Equals(book2);
        }

        public static bool operator !=(Book book1, Book book2)
        {
            return !(book1 == book2);
        }

        public override bool Equals(object obj)
        {
            var book = obj as Book;

            if (book != null)
            {
                return
                    book.Author.Equals(Author) &&
                    book.Name.Equals(Name) &&
                    book.Genre.Equals(Genre) &&
                    book.AdultOnly.Equals(AdultOnly);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion Equals
    }

}
