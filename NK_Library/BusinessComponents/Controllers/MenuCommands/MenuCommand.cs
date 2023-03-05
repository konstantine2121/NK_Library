using System;

namespace NK_Library.BusinessComponents.Controllers.MenuCommands
{
    internal class MenuCommand
    {
        private Action _action;

        public MenuCommand(string description, Action action)
        {
            Description = description;
            _action = action;
        }

        public string Description { get; }

        public void PerformAction()
        {
            _action?.Invoke();
        }
    }
}