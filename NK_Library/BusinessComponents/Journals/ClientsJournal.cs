using NK_Library.Dto;
using NK_Library.Interfaces.BusinessComponents.Journals;
using System.Collections.Generic;
using System.Linq;

namespace NK_Library.BusinessComponents.Journals
{
    /// <summary>
    /// Журнал учета клиентов.
    /// </summary>
    internal class ClientsJournal : IReadOnlyClientsJournal
    {
        private readonly IdCounter _clientCounter = new IdCounter(0);
        private Dictionary<int, Client> _clients = new Dictionary<int, Client>();

        public bool RegisterClient(Client client)
        {
            if (client == null || CheckClientExists(client))
            {
                return false;
            }

            _clients.Add(_clientCounter.Increment(), client);

            return true;
        }

        public IReadOnlyDictionary<int, Client> Clients => new Dictionary<int, Client>(_clients);

        public bool UnregisterClient(Client client)
        {
            if (client == null || !CheckClientExists(client))
            {
                return false;
            }

            var id = _clients.First(pair => pair.Value == client).Key;

            _clients.Remove(id);

            return true;
        }

        public bool UnregisterClient(int clientId)
        {
            if (!CheckClientExists(clientId))
            {
                return false;
            }

            _clients.Remove(clientId);

            return true;
        }

        public bool UpdateClient(int clientId, Client newInfo)
        {

            if (newInfo == null || !CheckClientExists(clientId))
            {
                return false;
            }

            _clients[clientId] = newInfo;

            return true;
        }

        /// <summary>
        /// Посетитель есть в списке зарегистрированных клиентов.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public bool CheckClientExists(Client client)
        {
            if (client == null)
            {
                return false;
            }

            return _clients.ContainsValue(client);
        }

        public bool CheckClientExists(int clientId)
        {
            return _clients.ContainsKey(clientId);
        }
    }
}
