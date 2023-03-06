using NK_Library.Dto;
using NK_Library.Interfaces.BusinessComponents.Journals;
using System.Collections.Generic;
using System.Linq;

namespace NK_Library.BusinessComponents.Journals
{
    /// <summary>
    /// Журнал учата выдачи книг клиентам.
    /// </summary>
    internal class BookOutsideJournal
    {
        private List<BookOutside> _bookOutside = new List<BookOutside>();

        public BookOutsideJournal(IReadOnlyBooksJournal booksJournal, IReadOnlyClientsJournal clientsJournal)
        {
            BooksJournal = booksJournal;
            ClientsJournal = clientsJournal;
        }

        public IEnumerable<BookOutside> BookOutsides => _bookOutside;

        public IReadOnlyBooksJournal BooksJournal { get; }

        public IReadOnlyClientsJournal ClientsJournal { get; }

        public bool CheckBookOutside(Book book)
        {
            return _bookOutside.Any(item => item.Book == book);
        }

        /// <summary>
        /// Получить список тех, у кого на руках книги.
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<Client> GetClientsWithBooks()
        {
            var clientList = _bookOutside.Select(pair => pair.Client)
                .Distinct()
                .ToList();

            clientList.Sort((a, b) => string.Compare(a.FullName, b.FullName));

            return clientList;
        }

        /// <summary>
        /// Получить список всех книг на выдаче.
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<Book> GetBooksOutside()
        {
            return _bookOutside.Select(pair => pair.Book)
                .ToList();
        }

        /// <summary>
        /// Пытаемся выдать книгу клиенту.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="book"></param>
        /// <returns></returns>
        public bool TryGiveBookToClient(Client client, Book book)
        {
            if (!ClientsJournal.CheckClientExists(client) ||
                !BooksJournal.CheckBookExists(book) ||
                CheckBookOutside(book))
            {
                return false;
            }

            _bookOutside.Add(new BookOutside(book, client));

            return true;
        }

        /// <summary>
        /// Возвращаем книгу в библиотеку.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public bool TryReturnBookToLibrary(Book book)
        {
            if (!BooksJournal.CheckBookExists(book))
            {
                return false;
            }

            _bookOutside.RemoveAll(item => item.Book == book);

            return true;
        }
    }
}
