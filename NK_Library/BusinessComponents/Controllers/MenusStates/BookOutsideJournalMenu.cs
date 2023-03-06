using NK_Library.BusinessComponents.Controllers.MenuCommands;
using NK_Library.BusinessComponents.InfoPrinters;
using NK_Library.BusinessComponents.Journals;
using NK_Library.BusinessComponents.Selectors;
using NK_Library.ConsoleInputOutput;
using NK_Library.Dto;
using NK_Library.Interfaces.BusinessComponents.Controllers.MenusStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK_Library.BusinessComponents.Controllers.MenusStates
{
    internal class BookOutsideJournalMenu : BaseMenuState
    {
        private readonly BookInfoPrinter _bookPrinter = new BookInfoPrinter();
        private readonly ClientInfoPrinter _clientPrinter = new ClientInfoPrinter();

        private readonly ClientSelector _clientSelector;
        private readonly BookSelector _bookSelector;

        public BookOutsideJournalMenu(IMenuContext menuContext, IMenuStatesProvider statesProvider, BookOutsideJournal bookOutsideJournal) : base(menuContext, statesProvider)
        {
            BookOutsideJournal = bookOutsideJournal;

            _clientSelector = new ClientSelector(BookOutsideJournal.ClientsJournal);
            _bookSelector = new BookSelector(BookOutsideJournal.BooksJournal);
        }

        public override string Name => "Журнал учета выдачи/возврата книг.";

        public BookOutsideJournal BookOutsideJournal { get; }

        protected override void RegisterCommands()
        {
            Commands.Clear();
            Commands.Add(1, new MenuCommand("Показать список выданных книг.", PrintAllOutsideBooks));
            Commands.Add(2, new MenuCommand("Показать список клиентов у кого книги на руках.", PrintAllClientsWithBooks));
            Commands.Add(3, new MenuCommand("Выдать книгу.", GiveBookToClient));
            Commands.Add(4, new MenuCommand("Вернуть книгу.", ReturnBook));
            Commands.Add(5, new MenuCommand("Вернуться в меню.", ReturnToMain));
        }

        private void PrintAllOutsideBooks()
        {
            Output.PrintInfo("Список выданных книг.");
            _bookPrinter.PrintInfos(BookOutsideJournal.GetBooksOutside());

            PrintInputWelcome();
        }

        private void PrintAllClientsWithBooks()
        {
            Output.PrintInfo("Список клиентов с книгами на руках.");
            _clientPrinter.PrintInfos(BookOutsideJournal.GetClientsWithBooks());

            PrintInputWelcome();
        }

        private void GiveBookToClient()
        {
            Output.PrintInfo("Выберите клиента которому выдать книгу.");
            Output.PrintInfo("Список клиентов.");
            _clientPrinter.PrintInfos(BookOutsideJournal.ClientsJournal.Clients);


            if (!_clientSelector.Select(out int clientId, out Client client))
            {
                Output.PrintWarning("Клиент не найден.");

                PrintInputWelcome();
                return;
            }

            Output.PrintInfo("Список книг в наличии в библиотеке.");
            
            var booksInside = BookOutsideJournal.BooksJournal
                .Books.Where(pair => !BookOutsideJournal.CheckBookOutside(pair.Value));

            _bookPrinter.PrintInfos(booksInside);

            if (!_bookSelector.Select(out int bookId, out Book book))
            {
                Output.PrintWarning("Книга не найдена.");

                PrintInputWelcome();
                return;
            }

            if (BookOutsideJournal.CheckBookOutside(book))
            {
                Output.PrintWarning("Книга находится на руках.");

                PrintInputWelcome();
                return;
            }
            
            if (BookOutsideJournal.TryGiveBookToClient(client, book))
            {
                Output.PrintInfo("Книга выдана клиенту.");
            }
            else 
            {
                Output.PrintError("При попытке выдачи книги произошла ошибка.");
            }

            PrintInputWelcome();
        }

        private void ReturnBook()
        {
            Output.PrintInfo("Возвращаем книгу в бибилиотеку.");

            Output.PrintMessage(ConsoleColor.Magenta ,"Список книг на выдаче.");

            var booksOutside = BookOutsideJournal.BooksJournal
                .Books.Where(pair => BookOutsideJournal.CheckBookOutside(pair.Value));

            _bookPrinter.PrintInfos(booksOutside);

            if (!_bookSelector.Select(out int bookId, out Book book))
            {
                Output.PrintWarning("Книга не найдена.");

                PrintInputWelcome();
                return;
            }

            if (!BookOutsideJournal.CheckBookOutside(book))
            {
                Output.PrintWarning("Книга и так находится в библиотеке.");

                PrintInputWelcome();
                return;
            }

            if (BookOutsideJournal.TryReturnBookToLibrary(book))
            {
                Output.PrintInfo("Возвращаем книгу в библиотеку.");
            }
            else
            {
                Output.PrintError("При попытке возврата книги произошла ошибка.");
            }

            PrintInputWelcome();
        }

        private void ReturnToMain()
        {
            MenuContext.SetNextState(StatesProvider.MainMenu);
        }
    }
}
