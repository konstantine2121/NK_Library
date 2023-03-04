using NK_Library.ConsoleInputOutput;
using NK_Library.Dto;
using NK_Library.Interfaces.BusinessComponents.ManualCreators;

namespace NK_Library.BusinessComponents.ManualCreators
{
    /// <summary>
    /// Регистрация книги из консоли.
    /// </summary>
    internal class BookCreator : IManualCreator<Book>
    {
        public bool TryCreate(out Book item)
        {
            item = null;

            Output.PrintInfo("Регистрация новой книги.");
            Output.PrintWarning($"Введите '{Enums.ConsoleComands.Exit}' для выхода.");

            string author = default;
            string bookName = default;
            string genre = default;
            bool adultOnly = default;
            int yearOfPublication = default;

            bool success = false;

            success = InterruptableInput.TryReadString("Введите имя автора:", out author);

            if (!success) 
            {
                PrintAbortWarning();
                return false;
            }

            success = InterruptableInput.TryReadString("Введите имя книги:", out bookName);

            if (!success)
            {
                PrintAbortWarning();
                return false;
            }
            success = InterruptableInput.TryReadString("Введите жанр:", out genre);

            if (!success)
            {
                PrintAbortWarning();
                return false;
            }
            success = InterruptableInput.TryReadBoolean("Введите есть ли ограничение по возрасту (0 - нет / 1-есть):", out adultOnly);

            if (!success)
            {
                PrintAbortWarning();
                return false;
            }
            success = InterruptableInput.TryReadPositiveInteger("Введите год публикации:", out yearOfPublication);

            if (!success)
            {
                PrintAbortWarning();
                return false;
            }

            item = new Book(
                author,
                bookName,
                genre,
               adultOnly,
                yearOfPublication
                );

            return true;
        }

        private void PrintAbortWarning()
        {
            Output.PrintWarning("Ввод данных прерван.");
        }
    }
}