using NK_Library.ConsoleInputOutput;
using NK_Library.Dto;
using NK_Library.Interfaces.BusinessComponents.ManualCreators;
using System;

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

            Output.PrintInfo("Ввод данных по книге.");
            Output.PrintWarning($"Введите '{Enums.ConsoleComands.Exit}' для выхода.");

            string author = default;
            string bookName = default;
            string genre = default;
            bool adultOnly = default;
            int yearOfPublication = default;

            Func<bool>[] functions =
            {
                () => InterruptableInput.TryReadString("Введите имя автора:", out author),
                () => InterruptableInput.TryReadString("Введите имя книги:", out bookName),
                () => InterruptableInput.TryReadString("Введите жанр:", out genre),
                () => InterruptableInput.TryReadBoolean("Введите есть ли ограничение по возрасту (0 - нет / 1-есть):", out adultOnly),
                () => InterruptableInput.TryReadPositiveInteger("Введите год публикации:", out yearOfPublication)
            };

            foreach(var function in functions) 
            {
                bool continueInput = function();
                if (!continueInput)
                {
                    PrintAbortWarning();
                    return false;
                }
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