using NK_Library.BusinessComponents.Controllers.MenuCommands;
using NK_Library.BusinessComponents.InfoPrinters;
using NK_Library.BusinessComponents.Journals;
using NK_Library.BusinessComponents.ManualCreators;
using NK_Library.BusinessComponents.Selectors;
using NK_Library.ConsoleInputOutput;
using NK_Library.Dto;
using NK_Library.Interfaces.BusinessComponents.Controllers.MenusStates;
using System.Linq;

namespace NK_Library.BusinessComponents.Controllers.MenusStates
{
    internal class ClientsJournalMenu : BaseMenuState
    {
        private readonly ClientSelector _clientSelector;
        private readonly ClientInfoPrinter _printer = new ClientInfoPrinter();
        private readonly ClientCreator _bookCreator = new ClientCreator();

        public ClientsJournalMenu(IMenuContext menuContext, IMenuStatesProvider statesProvider, ClientsJournal clientsJournal) : base(menuContext, statesProvider)
        {
            ClientsJournal = clientsJournal;
            _clientSelector = new ClientSelector(ClientsJournal);
        }

        public override string Name => "Журнал регистрации книг";

        private ClientsJournal ClientsJournal { get; }

        protected override void RegisterCommands()
        {
            Commands.Clear();

            Commands.Add(1, new MenuCommand("Показать список клиентов.", ShowClients));
            Commands.Add(2, new MenuCommand("Добавить клиента.", AddClient));
            Commands.Add(3, new MenuCommand("Удалить клиента.", RemoveClient));
            Commands.Add(4, new MenuCommand("Обновить данные клиента.", UpdateClient));
            Commands.Add(5, new MenuCommand("Вернуться в главное меню.", ReturnToMain));
        }

        private void ShowClients()
        {
            Output.PrintInfo("Список клиентов.");
            _printer.PrintInfos(ClientsJournal.Clients);

            PrintInputWelcome();
        }

        private void AddClient()
        {
            var notCanceled = _bookCreator.TryCreate(out Client client);

            if (notCanceled)
            {
                if (ClientsJournal.RegisterClient(client))
                {
                    Output.PrintInfo("Клиент добавлен.");
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

        private void RemoveClient()
        {
            if (_clientSelector.Select(out int id, out Client client))
            {
                if (ClientsJournal.UnregisterClient(client))
                {
                    Output.PrintInfo("Клиент удален.");
                }
                else
                {
                    Output.PrintError("Ошибка при удалении.");
                }
            }
            else
            {
                Output.PrintWarning("Клиент не найден.");
            }

            PrintInputWelcome();
        }

        private void UpdateClient()
        {
            Output.PrintInfo("Выберите клиента для изменения данных.");

            if (!_clientSelector.Select(out int id, out Client clientOld))
            {
                Output.PrintWarning("Клиент не найден.");

                PrintInputWelcome();
                return;
            }

            Output.PrintInfo("Старые данные.");
            _printer.PrintInfo(clientOld);

            Output.PrintInfo("Ввод новых данных.");

            var notCanceled = _bookCreator.TryCreate(out Client client);

            if (notCanceled)
            {
                if (ClientsJournal.UpdateClient(id, client))
                {
                    Output.PrintInfo("Запись обновлена.");
                }
                else
                {
                    Output.PrintError("Ошибка при обновлении.");
                }
            }
            else
            {
                Output.PrintWarning("Операция отменена.");
            }

            PrintInputWelcome();

        }

        private void ReturnToMain()
        {
            MenuContext.SetNextState(StatesProvider.MainMenu);
        }
    }
}
