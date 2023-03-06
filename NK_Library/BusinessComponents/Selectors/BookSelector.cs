using NK_Library.BusinessComponents.Journals;
using NK_Library.Dto;
using NK_Library.Interfaces.BusinessComponents.Selectors;
using NK_Library.ConsoleInputOutput;
using System;

namespace NK_Library.BusinessComponents.Selectors
{
    internal class BookSelector : ISelector<Book>
    {
        private readonly BooksJournal _booksJournal;

        public BookSelector(BooksJournal booksJournal)
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
