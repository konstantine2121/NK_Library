using NK_Library.ConsoleInputOutput;
using NK_Library.Dto;
using NK_Library.Interfaces.BusinessComponents.ManualCreators;

namespace NK_Library.BusinessComponents.ManualCreators
{
    internal class BookCreator : IManualCreator<Book>
    {
        public bool TryCreate(out Book item)
        {
            item = new Book(
                InputAuthor(),
                InputBookName(),
                InputGenre(),
                InputIsAdultOnly(),
                InputYearOfPublication()
                );

            return true;
        }

        private string InputAuthor()
        {
            return Input.ReadString("Введите имя автора:");
        }

        private string InputBookName()
        {
            return Input.ReadString("Введите имя книги:");
        }

        private string InputGenre()
        {
            return Input.ReadString("Введите жанр:");
        }

        private bool InputIsAdultOnly()
        {
            return Input.ReadBoolean("Введите есть ли ограничение по возрасту:");
        }

        private int InputYearOfPublication()
        {
            return Input.ReadPositiveInteger("Введите год публикации:");
        }
    }
}