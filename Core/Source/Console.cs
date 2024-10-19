
using Shell = System.Console;

namespace Blenordia.Source
{
    // TODO [+] [10/10/2024 18:57] Make class static

    public static class Console
    {
        public static bool IsDebug = true;

        public static void WriteInfo(string message)
        {
            WriteTag("INFO", ConsoleColor.DarkGray);
            WriteLine(message);
        }

        public static void WriteFine(string message)
        {
            WriteTag("FINE", ConsoleColor.DarkGreen);
            WriteLine(message);
        }

        public static void WriteError(string message)
        {
            WriteTag("ERROR", ConsoleColor.Red);
            WriteLine(message);
        }

        public static void WriteDebug(string message)
        {
            if (IsDebug)
            {
                WriteTag("DEBUG", ConsoleColor.DarkYellow);
                WriteLine(message);
            }
        }

        public static void WriteWarning(string message)
        {
            WriteTag("WARNING", ConsoleColor.Yellow);
            WriteLine(message);
        }

        public static void WriteLog(string message)
        {
            WriteTag("LOG", ConsoleColor.White);
            WriteLine(message);
        }

        public static void WriteLagged(string message)
        {
            WriteTag("LAGGED", ConsoleColor.DarkMagenta);
            WriteLine(message);
        }

        public static void WriteInput(string message, out string? input)
        {
            WriteTag("INPUT", ConsoleColor.Magenta);
            Write(message);
            input = Shell.ReadLine();
        }

        private static void WriteLine(string message)
        {
            Shell.WriteLine(message);
        }

        private static void Write(string message)
        {
            Shell.Write(message);
        }

        private static void WriteTag(string tag, ConsoleColor color)
        {
            Shell.ForegroundColor = ConsoleColor.White;
            Shell.Write("[");
            Shell.ForegroundColor = color;
            Shell.Write(tag);
            Shell.ForegroundColor = ConsoleColor.White;
            Shell.Write("] ");
        }
    }
}