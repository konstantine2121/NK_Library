using NK_Library.Dto;
using System.Collections.Generic;

namespace NK_Library.Interfaces.BusinessComponents.Journals
{
    internal interface IReadOnlyClientsJournal
    {
        IReadOnlyDictionary<int, Client> Clients { get; }

        /// <summary>
        /// Посетитель есть в списке зарегистрированных клиентов.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        bool CheckClientExists(Client client);

        bool CheckClientExists(int clientId);
    }
}
