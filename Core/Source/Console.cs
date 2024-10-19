namespace Blenordia.Source
{
    // TODO [ ] [10/10/2024 13:33] Refactor Console.Write...() methods
    // TODO [ ] [10/12/2024 15:37] Add Console.WriteLine...() methods

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
            input = System.Console.ReadLine();
        }

        private static void WriteLine(string message)
        {
            System.Console.WriteLine(message);
        }

        private static void Write(string message)
        {
            System.Console.Write(message);
        }

        private static void WriteTag(string tag, ConsoleColor color)
        {
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.Write("[");
            System.Console.ForegroundColor = color;
            System.Console.Write(tag);
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.Write("] ");
        }
    }
}