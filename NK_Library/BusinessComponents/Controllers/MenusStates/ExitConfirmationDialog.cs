using NK_Library.BusinessComponents.Controllers.MenuCommands;
using NK_Library.Interfaces.BusinessComponents.Controllers.MenusStates;
using System;
using System.Collections.Generic;

namespace NK_Library.BusinessComponents.Controllers.MenusStates
{
    internal class ExitConfirmationDialog : BaseMenuState
    {
        public ExitConfirmationDialog(IMenuContext menuContext, IMenuStatesProvider statesProvider) : base(menuContext, statesProvider)
        {
        }

        public override string Name => "Вы хотите выйти?";

        protected override Dictionary<int, MenuCommand> Commands => new Dictionary<int, MenuCommand>
        {
            [1] = new MenuCommand("Вернуться в главное меню", ReturnToMain),
            [2] = new MenuCommand("Выход из программы", Exit)
        };

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
