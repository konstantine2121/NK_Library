using System;

namespace NK_Library.ConsoleInputOutput
{
    internal static class InterruptableInput
    {
        /// <summary>
        /// Считывает с консоли положительное значение натурального числа.
        /// </summary>
        /// <param name="message">Информационное сообщение, отображаемое перед вводом данных.</param>
        /// <returns>Положительное значение числа.</returns>
        public static bool TryReadPositiveInteger(string message, out int result)
        {
            result = default;
            bool parsed = false;

            while (parsed == false)
            {
                Console.Write(message);

                var input = Console.ReadLine();

                if (CheckCallExit(input))
                {
                    result = default;
                    return false;
                }

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

            return true;
        }

        /// <summary>
        /// Считывает с консоли булево значение.
        /// </summary>
        /// <param name="message">Информационное сообщение, отображаемое перед вводом данных.</param>
        /// <returns>Булево значение числа.</returns>
        public static bool TryReadBoolean(string message, out bool result)
        {
            result = default;
            bool parsed = false;
            int integer = 0;

            while (parsed == false)
            {
                Console.Write(message);

                var input = Console.ReadLine();

                if (CheckCallExit(input))
                {
                    result = default;
                    return false;
                }
                parsed = int.TryParse(input, out integer);

                if (parsed == false)
                {
                    Output.PrintWarning("Не получилось распознать значение. Попробуйте еще раз.");
                }
                else
                {
                    if (integer != 0 && integer != 1)
                    {
                        parsed = false;
                        Output.PrintWarning("Значение должно равняться 0 или 1. Попробуйте еще раз.");
                    }
                }
            }

            return integer == 0 ? false : true;
        }

        /// <summary>
        /// Считывает с консоли значение натурального числа.
        /// </summary>
        /// <param name="message">Информационное сообщение, отображаемое перед вводом данных.</param>
        /// <returns>Значение числа.</returns>
        public static bool TryReadInteger(string message, out int result)
        {
            bool parsed = false;
            result = default;

            while (parsed == false)
            {
                Console.Write(message);

                var input = Console.ReadLine();

                if (CheckCallExit(input))
                {
                    result = default;
                    return false;
                }

                parsed = int.TryParse(input, out result);

                if (parsed == false)
                {
                    Output.PrintWarning("Не получилось распознать значение. Попробуйте еще раз.");
                }
            }

            return true;
        }

        /// <summary>
        /// Считывает с консоли значение строки.
        /// </summary>
        /// <param name="message">Информационное сообщение, отображаемое перед вводом данных.</param>
        /// <returns></returns>
        public static bool TryReadString(string message, out string result)
        {

            result = default;
            string input = string.Empty;

            while (string.IsNullOrEmpty(input))
            {
                Console.Write(message);
                input = Console.ReadLine();

                if (CheckCallExit(input))
                {
                    result = default;
                    return false;
                }

                if (string.IsNullOrEmpty(input))
                {
                    Output.PrintWarning("Введена пустая строка. Попробуйте еще раз.");
                }
            }

            return true;
        }

        public static bool CheckCallExit(string input)
        {
            return Enums.ConsoleComands.Exit.Equals(input);
        }
    }
}
