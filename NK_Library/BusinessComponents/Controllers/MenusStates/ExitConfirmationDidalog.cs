using NK_Library.BusinessComponents.Controllers.MenuCommands;
using NK_Library.Interfaces.BusinessComponents.Controllers.MenusStates;
using System;

namespace NK_Library.BusinessComponents.Controllers.MenusStates
{
    internal class ExitConfirmationDidalog : BaseMenuState
    {
        public ExitConfirmationDidalog(IMenuContext menuContext, IMenuStatesProvider statesProvider) : base(menuContext, statesProvider)
        {
        }

        public override string Name => "Вы хотите выйти?";

        protected override void RegisterCommands()
        {
            Commands.Clear();

            Commands.Add(1, new MenuCommand("Вернуться в главное меню", ReturnToMain));
            Commands.Add(2, new MenuCommand("Выход из программы", Exit));
        }

        private void ReturnToMain()
        {
            MenuContext.SetNextState(StatesProvider.MainMenu);
        }

        private void Exit()
        {
            Environment.Exit(0);
        }
    }
}
