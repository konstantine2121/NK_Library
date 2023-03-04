using NK_Library.ConsoleInputOutput;
using NK_Library.Dto;
using NK_Library.Interfaces.BusinessComponents;
using System.Collections.Generic;

namespace NK_Library.BusinessComponents.InfoPrinters
{
    internal class ClientInfoPrinter : IInfoPrinter<Client>
    {
        /// <summary>
        /// "{FullName, -20} {Birthday, -20} {PhoneNumber, -20}"       
        /// </summary>
        private const string Format = "{0, -20} {1, -20} {2, -20}";

        public void PrintInfo(Client client)
        {
            if (client == null)
            {
                Output.PrintWarning("Нет ссылки на клиента.");
                return;
            }

            PrintHeaders();

            System.Console.WriteLine(GetClientInfo(client));
        }

        public void PrintInfos(IEnumerable<Client> clients)
        {
            if (clients == null)
            {
                Output.PrintWarning("Нет ссылки на список клиентов.");
                return;
            }

            PrintHeaders();

            foreach (var client in clients)
            {
                System.Console.WriteLine(GetClientInfo(client));
            }
        }

        public void PrintHeaders()
        {
            Output.PrintInfo(Format, "ФИО", "День рождения", "Номер телефона");
        }

        public string GetClientInfo(Client client)
        {
            if (client == null)
            {
                return "Нет ссылки на клиента.";
            }

            return string.Format(Format,
                    client.FullName,
                    client.Birthday.ToString("dd.MM.yyyy"),
                    client.PhoneNumber);
        }
    }
}
