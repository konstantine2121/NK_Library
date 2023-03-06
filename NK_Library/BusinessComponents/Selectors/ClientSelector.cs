using NK_Library.BusinessComponents.Journals;
using NK_Library.ConsoleInputOutput;
using NK_Library.Dto;
using NK_Library.Interfaces.BusinessComponents.Selectors;
using System;

namespace NK_Library.BusinessComponents.Selectors
{
    internal class ClientSelector : ISelector<Client>
    {
        private readonly ClientsJournal _clientsJournal;

        public ClientSelector(ClientsJournal clientsJournal)
        {
            if (clientsJournal == null)
            {
                throw new ArgumentNullException(nameof(clientsJournal));
            }

            _clientsJournal = clientsJournal;
        }

        public bool Select(out int id, out Client client)
        {
            client = null;

            id = Input.ReadPositiveInteger("Введите id клиента:");

            if (_clientsJournal.CheckClientExists(id))
            {
                client = _clientsJournal.Clients[id];

                return true;
            }

            return false;
        }
    }
}
