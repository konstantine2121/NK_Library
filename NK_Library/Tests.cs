using NK_Library.BusinessComponents.Builders;
using NK_Library.BusinessComponents.Controllers.MenusStates;
using NK_Library.BusinessComponents.InfoPrinters;
using NK_Library.BusinessComponents.ManualCreators;
using NK_Library.ConsoleInputOutput;
using NK_Library.Dto;
using NK_Library.Interfaces.BusinessComponents.Controllers.MenusStates;
using NK_Library.Interfaces.BusinessComponents;
using System;

namespace NK_Library
{
    internal class Tests
    {

        public static void TestBookPrinters()
        {
            var book = new Book("1", "n", "g", false, 1900);

            IInfoPrinter<Book> infoPrinter = new BookInfoPrinter();

            infoPrinter.PrintInfo(null);
            infoPrinter.PrintInfo(book);
        }

        public static void TestClientPrinters()
        {
            var client = new Client("Фио", DateTime.Now, "+7******");

            IInfoPrinter<Client> infoPrinter = new ClientInfoPrinter();

            infoPrinter.PrintInfo(null);
            infoPrinter.PrintInfo(client);
        }

        public static void TestLibraryFactory()
        {
            var library = new LibraryFactoryBuilder().Build().Create();

            var clientsPrinter = new ClientInfoPrinter();
            var booksPrinter = new BookInfoPrinter();

            clientsPrinter.PrintInfos(
                library.ClientsJournal
                .Clients.Values);

            booksPrinter.PrintInfos(
                library.BooksJournal
                .Books.Values);
        }

        public static void TestManualCreators()
        {
            var bookCreator = new BookCreator();
            var clientCreator = new ClientCreator();

            var clientsPrinter = new ClientInfoPrinter();
            var booksPrinter = new BookInfoPrinter();

            Client client;

            if (clientCreator.TryCreate(out client))
            {
                Output.PrintInfo("Клиент успешно зарегистрирован!");
            }
            else
            {
                Output.PrintWarning("Операция отменена.");
            }

            Book book;

            if (bookCreator.TryCreate(out book))
            {
                Output.PrintInfo("Книга успешно зарегистрирована!");
            }
            else
            {
                Output.PrintWarning("Операция отменена.");
            }


            clientsPrinter.PrintInfo(client);

            booksPrinter.PrintInfo(book);
        }

        public static void TestMenu()
        {
            var library = new LibraryFactoryBuilder().Build().Create();

            IMenuContext menu = new MenuContext(library);

            while (menu.InvalidState == false)
            {
                menu.PerformAction();
            }
        }

    }
}
