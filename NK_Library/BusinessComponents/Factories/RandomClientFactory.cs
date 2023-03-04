using NK_Library.Dto;
using NK_Library.Interfaces.BusinessComponents.Factories;
using System;
using System.Text;

namespace NK_Library.BusinessComponents.Factories
{
    internal class RandomClientFactory : RandomContainer, ICreator<Client>
    {
        private readonly ICreator<string> _namesCreator;

        public RandomClientFactory(PeopleNamesFactory peopleNamesFactory) 
        {
            if (peopleNamesFactory == null)
            {
                throw new ArgumentNullException(nameof(peopleNamesFactory));
            }

            _namesCreator = peopleNamesFactory;
        }

        private int CurrentYear => DateTime.Now.Year;

        public Client Create()
        {
            return new Client(
                GetFullName(),
                GetBirthday(),
                GetPhoneNumber());
        }

        private string GetFullName()
        {
            return _namesCreator.Create();
        }

        private DateTime GetBirthday()
        {
            const int maxClientAge = 100;
            const int minClientAge = 7;
            const int monthsInYear = 12;

            int minYearRange = CurrentYear - maxClientAge;
            int maxYearRange = CurrentYear - minClientAge;

            int year = Rand.Next(minYearRange, maxYearRange+1);
            int month = Rand.Next(1, monthsInYear + 1);
            
            int daysInMonth = DateTime.DaysInMonth(year, month);

            int day = Rand.Next(1, daysInMonth + 1);

            return new DateTime(year,month,day);
        }

        private string GetPhoneNumber()
        {
            const int maxExclusiveNumber = 10;
            const int phoneNumberChangedPartLength  = 10;
            const string prefix = "+7";

            StringBuilder builder= new StringBuilder();

            builder.Append(prefix);

            for(int i=0; i< phoneNumberChangedPartLength; i++)
            {
                builder.Append(Rand.Next(maxExclusiveNumber).ToString());
            }

            return builder.ToString();
        }
    }
}
