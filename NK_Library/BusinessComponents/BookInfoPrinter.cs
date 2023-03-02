using NK_Library.Dto;
using NK_Library.Interfaces.BusinessComponents;
using System.Collections.Generic;

namespace NK_Library.BusinessComponents
{
    internal class BookInfoPrinter : IInfoPrinter<Book>
    {
        /// <summary>
        /// {Author, -20} {Name, -20} {Genre, -20} {AdultOnly, -5}        
        /// </summary>
        private const string Format = "{0, -20} {1, -20} {2, -20} {3, -5}";

        public void PrintInfo(Book book)
        {
            if (book == null)
            {
                Out.PrintWarning("Нет ссылки на книгу.");
                return;
            }

            PrintHeaders();

            Out.PrintInfo(GetBookInfo(book));
        }

        public void PrintInfos(IEnumerable<Book> books)
        {
            if (books == null)
            {
                Out.PrintWarning("Нет ссылки на коллекцию книг.");
                return;
            }

            PrintHeaders();

            foreach (Book book in books)
            {
                Out.PrintInfo(GetBookInfo(book));
            }
        }

        public void PrintHeaders()
        {
            Out.PrintInfo(Format, "Автор", "Название", "Жанр", "18+");
        }

        private string GetBookInfo(Book book)
        {
            if (book == null)
            {
                return "Нет ссылки на книгу.";
            }

            return string.Format(Format,
                    book.Author,
                    book.Name,
                    book.Genre,
                    book.AdultOnly.ToString());
        }
    }
}
