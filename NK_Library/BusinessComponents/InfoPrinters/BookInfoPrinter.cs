using NK_Library.ConsoleInputOutput;
using NK_Library.Dto;
using NK_Library.Interfaces.BusinessComponents;
using System;
using System.Collections.Generic;

namespace NK_Library.BusinessComponents.InfoPrinters
{
    internal class BookInfoPrinter : IInfoPrinter<Book>
    {
        /// <summary>
        /// {Author, -20} {Name, -20} {Genre, -20} {AdultOnly, -5} {YearOfPublication, -6}
        /// </summary>
        private const string Format = "{0, -20} {1, -20} {2, -20} {3, -5} {4, -6}";

        public void PrintInfo(Book book)
        {
            if (book == null)
            {
                Output.PrintWarning("Нет ссылки на книгу.");
                return;
            }

            PrintHeaders();

            Console.WriteLine(GetBookInfo(book));
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
                Console.WriteLine(GetBookInfo(book));
            }
        }

        public void PrintInfos(IEnumerable<KeyValuePair<int, Book> > books)
        {
            if (books == null)
            {
                Output.PrintWarning("Нет ссылки на коллекцию книг.");
                return;
            }

            Output.PrintInfo($"{"Id",5} {GetHeadersLine()}");

            foreach (var pair in books)
            {
                Console.WriteLine( $"{pair.Key, 5} {GetBookInfo(pair.Value)}");
            }
        }

        public void PrintHeaders()
        {
            Output.PrintInfo(GetHeadersLine());
        }

        private string GetHeadersLine()
        {
            return string.Format(Format, "Автор", "Название", "Жанр", "18+", "Год");
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
