
using NK_Library.Dto;
using System.Collections.Generic;
using System.Linq;

namespace NK_Library.BusinessComponents.Journals
{
    /// <summary>
    /// Журнал учета всех книг в библиотеке.
    /// </summary>
    internal class BooksJournal
    {
        private readonly IdCounter _booksCounter = new IdCounter(0);
        private Dictionary<int, Book> _books = new Dictionary<int, Book>();

        public bool RegisterBook(Book book)
        {
            if (book == null)
            {
                return false;
            }

            _books.Add(_booksCounter.Increment(), book);

            return true;
        }

        public IReadOnlyDictionary<int, Book> Books => new Dictionary<int, Book>(_books);

        public bool UnregisterBook(Book book)
        {
            if (book == null || !CheckBookExists(book))
            {
                return false;
            }

            var id = _books.First(pair => pair.Value == book).Key;

            _books.Remove(id);

            return true;
        }

        /// <summary>
        /// Книга есть в списке библиотеки.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public bool CheckBookExists(Book book)
        {
            if (book == null)
            {
                return false;
            }

            return _books.ContainsValue(book);
        }

        public bool CheckBookExists(int bookId)
        {
            return _books.ContainsKey(bookId);
        }

    }
}
