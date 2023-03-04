using System;

namespace NK_Library.ConsoleInputOutput
{
    /// <summary>
    /// Методы для считывания значений с консоли.
    /// </summary>
    internal static class Input
    {
        /// <summary>
        /// Считывает с консоли положительное значение натурального числа.
        /// </summary>
        /// <param name="message">Информационное сообщение, отображаемое перед вводом данных.</param>
        /// <returns>Положительное значение числа.</returns>
        public static int ReadPositiveInteger(string message)
        {
            int result = 0;
            bool parsed = false;

            while (parsed == false)
            {
                Console.Write(message);

                var input = Console.ReadLine();
                parsed = int.TryParse(input, out result);

                if (parsed == false)
                {
                    Output.PrintWarning("Не получилось распознать значение. Попробуйте еще раз.");
                }
                else
                {
                    if (result < 0)
                    {
                        parsed = false;
                        Output.PrintWarning("Значение не может быть отрицательным. Попробуйте еще раз.");
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Считывает с консоли булево значение.
        /// </summary>
        /// <param name="message">Информационное сообщение, отображаемое перед вводом данных.</param>
        /// <returns>Булево значение числа.</returns>
        public static bool ReadBoolean(string message)
        {
            int result = 0;
            bool parsed = false;

            while (parsed == false)
            {
                Console.Write(message);

                var input = Console.ReadLine();
                parsed = int.TryParse(input, out result);

                if (parsed == false)
                {
                    Output.PrintWarning("Не получилось распознать значение. Попробуйте еще раз.");
                }
                else
                {
                    if (result  != 0 && result != 1)
                    {
                        parsed = false;
                        Output.PrintWarning("Значение должно равняться 0 или 1. Попробуйте еще раз.");
                    }
                }
            }

            return result == 0 ? false : true;
        }

        /// <summary>
        /// Считывает с консоли значение натурального числа.
        /// </summary>
        /// <param name="message">Информационное сообщение, отображаемое перед вводом данных.</param>
        /// <returns>Значение числа.</returns>
        public static int ReadInteger(string message)
        {
            int result = 0;
            bool parsed = false;

            while (parsed == false)
            {
                Console.Write(message);

                var input = Console.ReadLine();
                parsed = int.TryParse(input, out result);

                if (parsed == false)
                {
                    Output.PrintWarning("Не получилось распознать значение. Попробуйте еще раз.");
                }
            }

            return result;
        }

        /// <summary>
        /// Считывает с консоли значение строки.
        /// </summary>
        /// <param name="message">Информационное сообщение, отображаемое перед вводом данных.</param>
        /// <returns></returns>
        public static string ReadString(string message)
        {
            string input = string.Empty;

            while (string.IsNullOrEmpty(input))
            {
                Console.Write(message);
                input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Output.PrintWarning("Введена пустая строка. Попробуйте еще раз.");
                }
            }

            return input;
        }
    }
}
