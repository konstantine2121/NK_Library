using NK_Library.BusinessComponents.Controllers.MenuCommands;
using NK_Library.BusinessComponents.InfoPrinters;
using NK_Library.BusinessComponents.Journals;
using NK_Library.BusinessComponents.ManualCreators;
using NK_Library.BusinessComponents.Selectors;
using NK_Library.ConsoleInputOutput;
using NK_Library.Dto;
using NK_Library.Interfaces.BusinessComponents.Controllers.MenusStates;

namespace NK_Library.BusinessComponents.Controllers.MenusStates
{
    internal class BooksJournalMenu : BaseMenuState
    {
        private readonly BookSelector _bookSelector;
        private readonly BookInfoPrinter _printer = new BookInfoPrinter();
        private readonly BookCreator _bookCreator = new BookCreator();

        public BooksJournalMenu(IMenuContext menuContext, IMenuStatesProvider statesProvider, BooksJournal booksJournal) : base(menuContext, statesProvider)
        {
            BooksJournal = booksJournal;
            _bookSelector = new BookSelector(BooksJournal);
        }

        public override string Name => "Журнал регистрации книг";

        private BooksJournal BooksJournal { get; }

        protected override void RegisterCommands()
        {
            Commands.Clear();

            Commands.Add(1, new MenuCommand("Показать книги.", ShowBooks));
            Commands.Add(2, new MenuCommand("Добавить книгу.", AddBook));
            Commands.Add(3, new MenuCommand("Удалить книгу.", RemoveBook));
            Commands.Add(4, new MenuCommand("Вернуться в главное меню.", ReturnToMain));
        }

        private void ShowBooks()
        {
            Output.PrintInfo("Список книг.");
            _printer.PrintInfos(BooksJournal.Books);

            PrintInputWelcome();
        }

        private void AddBook()
        {
            var notCanceled = _bookCreator.TryCreate(out Book book);

            if (notCanceled) 
            {
                if(BooksJournal.RegisterBook(book))
                {
                    Output.PrintInfo("Книга добавлена.");
                }
                else
                {
                    Output.PrintError("Ошибка при добавлении.");
                }
            }
            else 
            {
                Output.PrintWarning("Операция отменена.");
            }

            PrintInputWelcome();
        }

        private void RemoveBook() 
        {
            if (_bookSelector.Select(out Book book))
            {
                if (BooksJournal.UnregisterBook(book))
                {
                    Output.PrintInfo("Книга удалена.");
                }
                else
                {
                    Output.PrintError("Ошибка при удалении.");
                }
            }
            else
            {
                Output.PrintWarning("Книга не найдена.");
            }

            PrintInputWelcome();
        }

        private void ReturnToMain()
        {
            MenuContext.SetNextState(StatesProvider.MainMenu);
        }
    }
}
