using NK_Library.BusinessComponents.Journals;

namespace NK_Library.BusinessComponents
{
    /// <summary>
    /// Базовый класс для доступа ко всем журналам учета книг/клиентов.
    /// </summary>
    internal class Library
    {
        public Library()
        {
            BooksJournal = new BooksJournal();
            ClientsJournal = new ClientsJournal();
            BookOutsideJournal = new BookOutsideJournal(BooksJournal, ClientsJournal);
        }

        /// <summary>
        /// Журнал учета всех книг в библиотеке.
        /// </summary>
        public BooksJournal BooksJournal { get; private set; }

        /// <summary>
        /// Журнал учета клиентов.
        /// </summary>
        public ClientsJournal ClientsJournal { get; private set; }

        /// <summary>
        /// Журнал учата выдачи книг клиентам.
        /// </summary>
        public BookOutsideJournal BookOutsideJournal { get; private set; }
    }

}
