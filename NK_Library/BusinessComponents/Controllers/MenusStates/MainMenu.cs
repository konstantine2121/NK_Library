using NK_Library.BusinessComponents.Controllers.MenuCommands;
using NK_Library.Interfaces.BusinessComponents.Controllers.MenusStates;
using System.Collections.Generic;

namespace NK_Library.BusinessComponents.Controllers.MenusStates
{
    internal class MainMenu : BaseMenuState
    {
        public MainMenu(IMenuContext menuContext, IMenuStatesProvider statesProvider) : base(menuContext, statesProvider)
        {
        }

        public override string Name => "Главное меню";

        protected override Dictionary<int, MenuCommand> Commands => new Dictionary<int, MenuCommand>
        {
            [1] = new MenuCommand("Журнал книг.", OpenBooksJournal),
            [2] = new MenuCommand("Журнал клиентов.", OpenClientsJournal),
            [3] = new MenuCommand("Журнал выдачи книг.", OpenBooksOutsideJournal),
            [4] = new MenuCommand("Выход из программы.", OpenExitDialog)
        };

        private void OpenBooksJournal()
        {
            MenuContext.SetNextState(StatesProvider.BooksJournalMenu);
        }

        private void OpenClientsJournal()
        {
            MenuContext.SetNextState(StatesProvider.ClientsJournalMenu);
        }

        private void OpenBooksOutsideJournal()
        {
            MenuContext.SetNextState(StatesProvider.BookOutsideJournalMenu);
        }

        private void OpenExitDialog()
        {
            MenuContext.SetNextState(StatesProvider.ExitConfirmationDidalog);
        }
    }
}
