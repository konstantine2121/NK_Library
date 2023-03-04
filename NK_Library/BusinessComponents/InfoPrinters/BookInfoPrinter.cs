using NK_Library.ConsoleInputOutput;
using NK_Library.Dto;
using NK_Library.Interfaces.BusinessComponents;
using System.Collections.Generic;

namespace NK_Library.BusinessComponents.InfoPrinters
{
    internal class BookInfoPrinter : IInfoPrinter<Book>
    {
        /// <summary>
        /// {Author, -20} {Name, -20} {Genre, -20} {AdultOnly, -5} {YearOfPublication, -5}
        /// </summary>
        private const string Format = "{0, -20} {1, -20} {2, -20} {3, -5} {4, -5}";

        public void PrintInfo(Book book)
        {
            if (book == null)
            {
                Output.PrintWarning("Нет ссылки на книгу.");
                return;
            }

            PrintHeaders();

            System.Console.WriteLine(GetBookInfo(book));
        }

        public void PrintInfos(IEnumerable<Book> books)
        {
            if (books == null)
            {
                Output.PrintWarning("Нет ссылки на коллекцию книг.");
                return;
            }

            PrintHeaders();

            foreach (Book book in books)
            {
                System.Console.WriteLine(GetBookInfo(book));
            }
        }

        public void PrintHeaders()
        {
            Output.PrintInfo(Format, "Автор", "Название", "Жанр", "18+", "Год");
        }

        public string GetBookInfo(Book book)
        {
            if (book == null)
            {
                return "Нет ссылки на книгу.";
            }

            return string.Format(Format,
                    book.Author,
                    book.Name,
                    book.Genre,
                    book.AdultOnly.ToString(),
                    book.YearOfPublication);
        }
    }
}
