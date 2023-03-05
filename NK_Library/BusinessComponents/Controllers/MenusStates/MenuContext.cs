using NK_Library.Interfaces.BusinessComponents.Controllers.MenusStates;

namespace NK_Library.BusinessComponents.Controllers.MenusStates
{
    class MenuContext : IMenuContext
    {
        private IMenuState _currentState;

        public MenuContext()
        {

        }

        public string Name => "Главное меню";

        public void PerformAction()
        {
            _currentState?.PerformAction();
        }

        public void SetNextState(IMenuState state)
        {
            
        }
    }
}
