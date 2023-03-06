using NK_Library.ConsoleInputOutput;
using NK_Library.Dto;
using NK_Library.Interfaces.BusinessComponents.ManualCreators;
using System;

namespace NK_Library.BusinessComponents.ManualCreators
{
    internal class ClientCreator : IManualCreator<Client>
    {
        public bool TryCreate(out Client client) 
        {
            client = null;

            Output.PrintInfo("Ввод даных по клиенту.");
            Output.PrintWarning($"Введите '{Enums.ConsoleComands.Exit}' для выхода.");

            string fullName = default;
            DateTime birthday = default;
            string phoneNumber = default;

            Func<bool>[] functions =
            {
                () => InterruptableInput.TryReadString("Введите полное имя клиента:", out fullName),
                () => TryReadBirthday(out birthday),
                () => TryReadPhoneNumber(out phoneNumber)
            };

            foreach (var function in functions)
            {
                bool continueInput = function();
                if (!continueInput)
                {
                    PrintAbortWarning();
                    return false;
                }
            }

            client = new Client(fullName, birthday, phoneNumber);

            return true;
        }

        #region Birthday
        
        private bool TryReadBirthday(out DateTime dateTime)
        {
            dateTime = default;

            bool continueInput = true;
            string input = null;

            while (continueInput) 
            {
                continueInput = InterruptableInput.TryReadString("Введите дату рождения в формате 'dd.MM.yyyy':", out input);

                if (CheckDate(input, out dateTime))
                {
                    return true;
                }
                else
                {
                    Output.PrintWarning("Неверный формат даты.");
                }
            }

            return false;
        }

        private bool CheckDate(string input, out DateTime dateTime)
        {
            const char separator = '.';
            const int numberOfValues = 3;

            dateTime = default;

            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            var line = input.Trim();
            var parts = line.Split(separator);

            if (parts.Length != numberOfValues)
            {
                return false;
            }

            try
            {
                var day   = int.Parse(parts[0]);
                var month = int.Parse(parts[1]);
                var year  = int.Parse(parts[2]);

                dateTime = new DateTime(year, month, day);

                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }
        }

        #endregion Birthday

        #region PhoneNumber

        private bool TryReadPhoneNumber(out string phoneNumber)
        {
            const string beginPattern = "+7";

            phoneNumber = default;

            bool continueInput = true;
            string input = null;

            while (continueInput)
            {
                continueInput = InterruptableInput.TryReadString($"Введите номер телефона в формате {beginPattern}'**********': {beginPattern}", out input);

                if (CheckPhoneNumber(input))
                {
                    phoneNumber = beginPattern + input;
                    return true;
                }
                else
                {
                    Output.PrintWarning("Неверный формат номера телефона.");
                }
            }

            return false;
        }

        private bool CheckPhoneNumber(string input)
        {
            const int numberOfValues = 10;

            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            var line = input.Trim();
           
            return line.Length == numberOfValues && int.TryParse(line, out int number);
        }

        #endregion PhoneNumber

        private void PrintAbortWarning()
        {
            Output.PrintWarning("Ввод данных прерван.");
        }
    }
}
