﻿namespace Hathor.Web.Helpers
{
    public class ConsoleHelper
    {
        private static readonly ConsoleColor DarkColor = ConsoleColor.Black;
        private static readonly ConsoleColor BrightColor = ConsoleColor.White;
        private static readonly ConsoleColor OKColor = ConsoleColor.Cyan;
        private static readonly ConsoleColor WarningColor = ConsoleColor.Yellow;
        private static readonly ConsoleColor ErrorColor = ConsoleColor.Red;

        private static void Write(string text, ConsoleColor foregroundColor, bool newLine = false)
        {
            Console.BackgroundColor = DarkColor;
            Console.ForegroundColor = foregroundColor;
            if (newLine)
            {
                Console.WriteLine(text);
            }
            else
            {
                Console.Write(text);
            }
            Console.ResetColor();
        }

        private static void WriteLine(string text, ConsoleColor foregroundColor) => Write(text, foregroundColor, true);

        public static void NewLine() => Console.Write("\n");
        public static void WriteLine(string text) => WriteLine(text, BrightColor);
        public static void Write(string text) => Write(text, BrightColor);
        public static void OKWriteLine(string text) => WriteLine(text, OKColor);
        public static void OKWrite(string text) => Write(text, OKColor);
        public static void AccentWriteLine(string text) => WriteLine(text, WarningColor);
        public static void AccentWrite(string text) => Write(text, WarningColor);
        public static void ErrorWriteLine(string text) => WriteLine(text, ErrorColor);
        public static void ErrorWrite(string text) => Write(text, ErrorColor);

        private static void WriteSelectionList<T>(List<T> list)
        {
            for (int i = 0; i < list.Count(); i++)
            {
                var item = list[i];
                if (item is not null)
                {
                    Write("[");
                    OKWrite($"{i}");
                    Write("]\t");
                    Write(item.ToString() ?? string.Empty);
                    NewLine();
                }
            }
        }

        public static T Selection<T>(List<T> list, string? selectionText = null)
        {
            const int defaultSelectionValue = -1;
            const string defaultSelectionText = "Make your selection: ";
            if (!list.Any())
            {
                throw new Exception($"{nameof(list)} is empty.");
            }
            WriteSelectionList(list);
            int selection = defaultSelectionValue;
            while ((selection < 0 || selection > (list.Count - 1)) && list.Count > 1)
            {
                WriteLine("Make your selection using a numerical value. Natural numbers only as displayed in the list above.");
                Write($"{selectionText ?? defaultSelectionText}: ");
                string? answer = Console.ReadLine();
                if (answer is not null)
                {
                    try
                    {
                        selection = int.Parse(answer);
                    }
                    catch (Exception)
                    {
                        selection = defaultSelectionValue;
                    }
                }
            }
            if (list.Count == 1)
            {
                WriteLine("The selection only contains one item, otherwise you would had the option to choose.");
                return list.First();
            }
            if (selection >= 0 && list.Any())
            {
                return list.ToArray()[selection];
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(list));
            }
        }

        public static void WriteList<T>(List<T> list, string? prepend = null, string? append = null)
        {
            const string listStyle = "* ";
            foreach (var item in list)
            {
                OKWrite($"{listStyle}");
                WriteLine($"{prepend ?? string.Empty}{item}{append ?? string.Empty}");
            }
        }
    }
}
