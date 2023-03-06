using NK_Library.Dto;
using NK_Library.Interfaces.BusinessComponents.Selectors;
using NK_Library.ConsoleInputOutput;
using System;
using NK_Library.Interfaces.BusinessComponents.Journals;

namespace NK_Library.BusinessComponents.Selectors
{
    internal class BookSelector : ISelector<Book>
    {
        private readonly IReadOnlyBooksJournal _booksJournal;

        public BookSelector(IReadOnlyBooksJournal booksJournal)
        {
            if (booksJournal == null)
            {
                throw new ArgumentNullException(nameof(booksJournal));
            }

            _booksJournal = booksJournal;
        }

        public bool Select(out int id,out Book book)
        {
            book = null;

            id = Input.ReadPositiveInteger("Введите id книги:");

            if (_booksJournal.CheckBookExists(id))
            {
                book = _booksJournal.Books[id];

                return true;
            }

            return false;
        }

    }
}
