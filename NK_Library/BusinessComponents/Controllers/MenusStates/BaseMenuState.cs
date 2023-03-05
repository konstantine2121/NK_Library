using NK_Library.BusinessComponents.Controllers.MenuCommands;
using NK_Library.ConsoleInputOutput;
using NK_Library.Interfaces.BusinessComponents.Controllers.MenusStates;
using System;
using System.Collections.Generic;

namespace NK_Library.BusinessComponents.Controllers.MenusStates
{
    internal abstract class BaseMenuState : IMenuState
    {
        /// <summary>
        /// Список команд
        /// </summary>
        protected readonly Dictionary<int, MenuCommand> Commands = new Dictionary<int, MenuCommand>();

        protected readonly IMenuContext MenuContext;
        protected readonly IMenuStatesProvider StatesProvider;

        public BaseMenuState(IMenuContext menuContext, IMenuStatesProvider statesProvider)
        {
            if (menuContext == null)
            {
                throw new ArgumentNullException(nameof(menuContext));
            }

            if (statesProvider== null)
            {
                throw new ArgumentNullException(nameof(statesProvider));
            }

            MenuContext = menuContext;
            StatesProvider = statesProvider;
            RegisterCommands();
        }

        public abstract string Name { get; }

        /// <summary>
        /// Зарегистрировать команды для словаря Commands.
        /// </summary>
        protected abstract void RegisterCommands();

        public virtual void PerformAction()
        {
            Console.Clear();
            Output.PrintInfo(Name);
            PrintCommands();
            Console.WriteLine();
            InputCommandAndExecute();
        }

        protected virtual void PrintCommands() 
        {
            foreach (var command in Commands) 
            {
                var text = $"{command.Key} - {command.Value.Description}";
                Console.WriteLine(text);
            }
        }

        protected virtual void InputCommandAndExecute()
        {
            var number = Input.ReadPositiveInteger("Введите номер команды: ");

            if (Commands.ContainsKey(number))
            {
                Commands[number].PerformAction();
            }
            else
            {
                Output.PrintWarning("Команды с таким номером нет.");
                PrintInputWelcome();
            }
        }

        protected virtual void PrintInputWelcome()
        {
            Console.WriteLine("\nНажмите любую кнопку для ввода другой команды.");
            Console.ReadKey(true);
        }
    }
}
