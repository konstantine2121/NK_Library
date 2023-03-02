using NK_Library.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK_Library.BusinessComponents
{
    internal class Library
    {
        private readonly IdCounter _clientCounter = new IdCounter(1);
        private readonly IdCounter _booksCounter = new IdCounter(1);

        private Dictionary<int, Client> _clients = new Dictionary<int, Client>();
        private Dictionary<int, Book> _books =  new Dictionary<int, Book>();
        private List<BookOutside> _bookOutside = new List<BookOutside>();

        #region Учет клиентов

        public bool RegisterClient(Client client)
        {
            if (client == null || CheckClientExists(client)) 
            {
                return false;
            }

            _clients.Add(_clientCounter.Increment(), client);

            return true;
        }

        public bool UnregisterClient(Client client)
        {
            if (client == null || ! CheckClientExists(client))
            {
                return false;
            }

            var id = _clients.First(pair => pair.Value == client).Key;

            _clients.Remove(id);

            return true;
        }

        public bool UpdateClient(int clientId, Client newInfo)
        {

            if (newInfo == null || !CheckClientExists(clientId))
            {
                return false;
            }

            _clients[clientId] = newInfo;
            
            return true;
        }

        #endregion  Учет клиентов

        #region Учет книг

        public bool RegisterBook(Book book)
        {
            if (book == null)
            {
                return false;
            }

            _books.Add(_booksCounter.Increment(), book);

            return true;
        }

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

        #endregion Учет книг

        #region Выдача и возврат книг

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

            clientList.Sort((a,b)=> string.Compare(a.FullName, b.FullName));

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
            if (! CheckClientExists(client) || 
                ! CheckBookExists(book) ||
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
            if (! CheckBookExists(book))
            {
                return false;
            }

            _bookOutside.RemoveAll(item => item.Book == book);

            return true;
        }

        #endregion Выдача и возврат книг

        #region Exists

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

        /// <summary>
        /// Посетитель есть в списке зарегистрированных клиентов.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public bool CheckClientExists(Client client)
        {
            if (client == null)
            {
                return false;
            }

            return _clients.ContainsValue(client);
        }

        public bool CheckClientExists(int clientId)
        {
            return _clients.ContainsKey(clientId);
        }

        #endregion Exists
    }


}
