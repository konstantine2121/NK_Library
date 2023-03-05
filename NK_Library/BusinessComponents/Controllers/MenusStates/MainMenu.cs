using NK_Library.BusinessComponents.Controllers.MenuCommands;
using NK_Library.Interfaces.BusinessComponents.Controllers.MenusStates;


namespace NK_Library.BusinessComponents.Controllers.MenusStates
{
    internal class MainMenu : BaseMenuState
    {
        public MainMenu(IMenuContext menuContext, IMenuStatesProvider statesProvider) : base(menuContext, statesProvider)
        {
        }

        public override string Name => "Главное меню";

        protected override void RegisterCommands()
        {
            Commands.Clear();

            Commands.Add(1, new MenuCommand("Журнал книг.", OpenBooksJournal));
            Commands.Add(2, new MenuCommand("Журнал клиентов.", OpenClientsJournal));
            Commands.Add(3, new MenuCommand("Журнал выдачи книг.", OpenBooksOutsideJournal));
            Commands.Add(4, new MenuCommand("Выход из программы.", OpenExitDialog));
        }

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
