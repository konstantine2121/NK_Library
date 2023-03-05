using NK_Library.Interfaces.BusinessComponents.Controllers.MenusStates;

namespace NK_Library.BusinessComponents.Controllers.MenusStates
{
    class MenuContext : IMenuContext, IMenuStatesProvider
    {
        private IMenuState _currentState;

        public MenuContext()
        {

        }

        #region IMenuStatesProvider Implementation
        
        public IMenuState MainMenu => throw new System.NotImplementedException();

        public IMenuState ExitConfirmationDidalog => throw new System.NotImplementedException();

        public IMenuState Exit => throw new System.NotImplementedException();

        public IMenuState BooksJournalMenu => throw new System.NotImplementedException();

        public IMenuState ClientsJournalMenu => throw new System.NotImplementedException();

        public IMenuState BookOutsideJournalMenu => throw new System.NotImplementedException();

        #endregion IMenuStatesProvider Implementation


        #region IMenuContext Implementation
        
        public string Name => "Главное меню";

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
