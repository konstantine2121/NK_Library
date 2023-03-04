using NK_Library.BusinessComponents.Factories;

namespace NK_Library.BusinessComponents.Builders
{
    internal class LibraryFactoryBuilder
    {   
        public LibraryFactory Build()
        {
            var nameFactory = new PeopleNamesFactory();
            var bookFactory = new RandomBookFactory(nameFactory);
            var clientFactory = new RandomClientFactory(nameFactory);

            return new LibraryFactory(bookFactory, clientFactory);
        }
    }
}
