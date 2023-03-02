using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK_Library.BusinessComponents
{
    /// <summary>
    /// Вывод сообщения в консоль, используя заданный цвет.
    /// </summary>
    internal static class Out
    {
        private const ConsoleColor DefaultBackgroundColor =  ConsoleColor.Black;
        private const ConsoleColor DefaultForegroundColor =  ConsoleColor.White;

        private static readonly Stack<ConsoleColor> _backgrounds = new Stack<ConsoleColor>();
        private static readonly Stack<ConsoleColor> _foregrounds = new Stack<ConsoleColor>();

        public static void PrintMessage(ConsoleColor foregroundColor, string message)
        {
            SaveColors();

            Console.ForegroundColor = foregroundColor;
            Console.WriteLine(message);

            RestoreColors();
        }

        public static void PrintMessage(ConsoleColor foregroundColor, string format, params string[] args)
        {
            PrintMessage(foregroundColor, string.Format(format, args));
        }

        public static void PrintInfo(string message)
        {
            PrintMessage(ConsoleColor.Green, message);
        }

        public static void PrintInfo(string format, params string[] args)
        {
            PrintMessage(ConsoleColor.Green, format, args);
        }

        public static void PrintWarning(string message) 
        {
            PrintMessage(ConsoleColor.Yellow, message);
        }

        public static void PrintWarning(string format, params string[] args)
        {
            PrintMessage(ConsoleColor.Yellow, format, args);
        }

        public static void PrintError(string message) 
        {
            PrintMessage(ConsoleColor.Red, message);
        }

        public static void PrintError(string format, params string[] args)
        {
            PrintMessage(ConsoleColor.Red, format, args);
        }

        #region Colors Save/Restore

        private static void SaveColors()
        {
            SaveBackgroundColor();
            SaveForegroundColor();
        }

        private static void RestoreColors() 
        {
            RestoreBackgroundColor();
            RestoreForegroundColor();
        }

        private static void SaveBackgroundColor()
        {
            _backgrounds.Push(Console.BackgroundColor);
        }

        private static void RestoreBackgroundColor()
        {
            if (_backgrounds.Count > 0) 
            {
                Console.BackgroundColor = _backgrounds.Pop();
            }
            else
            {
                Console.BackgroundColor = DefaultBackgroundColor;
            }
        }

        private static void SaveForegroundColor() 
        {
            _foregrounds.Push(Console.ForegroundColor); 
        }

        private static void RestoreForegroundColor() 
        {
            if (_foregrounds.Count >0)
            {
                Console.ForegroundColor = _foregrounds.Pop();
            }
            else
            {
                Console.ForegroundColor = DefaultForegroundColor;
            }
        }

        #endregion Colors Save/Restore
    }
}
