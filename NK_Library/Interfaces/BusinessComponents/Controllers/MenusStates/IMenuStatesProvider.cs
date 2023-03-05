namespace NK_Library.Interfaces.BusinessComponents.Controllers.MenusStates
{
    internal interface IMenuStatesProvider
    {
        IMenuState MainMenu { get; }

        /// <summary>
        /// Окно подтверждения выхода из программы.
        /// </summary>
        IMenuState ExitConfirmationDidalog { get; }

        /// <summary>
        /// Осуществляет выход из программы.
        /// </summary>
        IMenuState Exit { get; }

        IMenuState BooksJournalMenu { get; }
        IMenuState ClientsJournalMenu { get; }
        IMenuState BookOutsideJournalMenu { get; }
    }
}
