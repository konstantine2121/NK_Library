using NK_Library.Dto;
using NK_Library.Interfaces.BusinessComponents.Factories;
using System;

namespace NK_Library.BusinessComponents.Factories
{
    internal class RandomBookFactory : RandomContainer, ICreator<Book>
    {
        private const int MinRangeOfYear = 1850;

        private readonly ICreator<string> _namesCreator;
        private readonly IdCounter _counter = new IdCounter(0);

        #region Genres

        private readonly string [] _genres = 
        {
            "Фантастика",
            "Классическая",
            "Детектив",
            "Приключения",
            "Исторический роман",
            "Любовный роман",
            "Психология",
            "Философия",
            "Религия",
            "Эзотерика",
            "Биография",
            "Триллер"
        };

        #endregion Genres

        private int CurrentYear => DateTime.Now.Year;

        public RandomBookFactory(PeopleNamesFactory peopleNamesFactory) 
        {
            if (peopleNamesFactory == null)
            {
                throw new ArgumentNullException(nameof(peopleNamesFactory));
            }

            _namesCreator = peopleNamesFactory;
        }

        public Book Create() 
        {
            return new Book(
                GetAuthor(), 
                GetNextBookName(),
                GetRandomGenre(),
                GetIsAdult(),
                GetPublicationYear());
        }

        private string GetAuthor()
        {
            return _namesCreator.Create();
        }

        private string GetRandomGenre()
        {
            return _genres[Rand.Next(_genres.Length)];
        }

        private string GetNextBookName()
        {
            var pattern = "Имя книги #";
            return pattern + _counter.Increment();
        }

        private bool GetIsAdult()
        {
            return Rand.Next(2) == 0 ?
                false :
                true;
        }

        private int GetPublicationYear()
        {
            return Rand.Next(MinRangeOfYear, CurrentYear+1);
        }
    }
}
