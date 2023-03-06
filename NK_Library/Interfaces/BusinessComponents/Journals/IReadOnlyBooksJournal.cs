using NK_Library.Dto;
using System.Collections.Generic;

namespace NK_Library.Interfaces.BusinessComponents.Journals
{
    internal interface IReadOnlyBooksJournal
    {
        IReadOnlyDictionary<int, Book> Books { get; }

        /// <summary>
        /// Книга есть в списке библиотеки.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        bool CheckBookExists(Book book);

        bool CheckBookExists(int bookId);
    }
}
