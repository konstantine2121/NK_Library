using NK_Library.Interfaces.BusinessComponents.Controllers.MenusStates;
using System;

namespace NK_Library.BusinessComponents.Controllers.MenusStates
{
    class MenuContext : IMenuContext, IMenuStatesProvider
    {
        private IMenuState _currentState;

        public MenuContext(Library library)
        {
            if (library == null)
            {
                throw new ArgumentNullException(nameof(library));
            }

            MainMenu = new MainMenu(this, this);
            ExitConfirmationDidalog = new ExitConfirmationDidalog(this, this);
            BooksJournalMenu = new BooksJournalMenu(this, this, library.BooksJournal);
            //ClientsJournalMenu
            //BookOutsideJournalMenu

            _currentState = MainMenu;
        }

        #region IMenuStatesProvider Implementation
        
        public IMenuState MainMenu { get; }

        public IMenuState ExitConfirmationDidalog { get; }

        public IMenuState BooksJournalMenu { get; }

        public IMenuState ClientsJournalMenu { get; }

        public IMenuState BookOutsideJournalMenu { get; }

        #endregion IMenuStatesProvider Implementation


        #region IMenuContext Implementation
        
        public string Name => "Главное меню";

        public bool InvalidState => _currentState == null;

        public void PerformAction()
        {
            _currentState?.PerformAction();
        }

        public void SetNextState(IMenuState state)
        {
            _currentState = state;
        }

        #endregion IMenuContext Implementation
    }
}
