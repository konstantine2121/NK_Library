using NK_Library.Dto;
using NK_Library.Interfaces.BusinessComponents.Factories;
using System;
using System.Collections.Generic;

namespace NK_Library.BusinessComponents.Factories
{
    internal class LibraryFactory : RandomContainer, ICreator<Library>
    {
        private const int MinNumberOfBooks = 10;
        private const int MaxNumberOfBooks = 40;

        private const int MinNumberOfClients = 5;
        private const int MaxNumberOfClients = 20;

        private ICreator<Book> _bookCreator;
        private ICreator<Client> _clientCreator;

        public LibraryFactory(RandomBookFactory randomBookFactory, RandomClientFactory randomClientFactory) 
        {
            if (randomBookFactory == null)
            {
                throw new ArgumentNullException(nameof(randomBookFactory));
            }

            if (randomClientFactory == null)
            {
                throw new ArgumentNullException(nameof(randomClientFactory));
            }

            _bookCreator = randomBookFactory;
            _clientCreator = randomClientFactory;
        }

        public Library Create() 
        {
            var library = new Library();

            var books = CreateBooks();
            var clients = CreateClients();

            foreach (var book in books) 
            {
                library.RegisterBook(book);
            }
            
            foreach (var client in clients) 
            {
                library.RegisterClient(client);
            }
            
            return library;
        }

        private IEnumerable<Book> CreateBooks() 
        {
            int amount = Rand.Next(MinNumberOfBooks, MaxNumberOfBooks+1);

            for (int i= 0; i< amount; i++)
            {
                yield return _bookCreator.Create();
            }
        }

        private IEnumerable<Client> CreateClients()
        {
            int amount = Rand.Next(MinNumberOfClients, MaxNumberOfClients + 1);

            for (int i = 0; i < amount; i++)
            {
                yield return _clientCreator.Create();
            }
        }

    }
}
