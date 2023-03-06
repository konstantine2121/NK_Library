using NK_Library.ConsoleInputOutput;
using NK_Library.Dto;
using NK_Library.Interfaces.BusinessComponents.ManualCreators;
using System;
using System.Linq;

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

            var continueInput = InterruptableInput.TryReadString("Введите полное имя клиента:", out fullName);

            if (!continueInput)
            {
                PrintAbortWarning();
                return false;
            }

            if (! TryReadBirthday(out birthday))
            {
                PrintAbortWarning();
                return false;
            }

            if (!TryReadPhoneNumber(out phoneNumber))
            {
                PrintAbortWarning();
                return false;
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
            phoneNumber = default;

            bool continueInput = true;
            string input = null;

            while (continueInput)
            {
                continueInput = InterruptableInput.TryReadString("Введите номер телефона в формате '+7**********':", out input);

                if (CheckPhoneNumber(input))
                {
                    phoneNumber = input;
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
            const string beginPattern= "+7";

            int totalChars = numberOfValues + beginPattern.Length;

            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            var line = input.Trim();

            if (line.Length != totalChars || 
                ! line.StartsWith(beginPattern))
            {
                return false;
            }

            line = line.Substring(beginPattern.Length);

            return line.ToCharArray().All(ch => char.IsDigit(ch));
        }

        #endregion PhoneNumber

        private void PrintAbortWarning()
        {
            Output.PrintWarning("Ввод данных прерван.");
        }
    }
}
