using System;

namespace OSD600.GoodLinkOrBadLink
{
    class CustomConsoleOutput
    {
        public static void WriteInGreen(string type, string url)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[{0}] ", type);
            Console.ResetColor();
            Console.WriteLine(url);
        }

        public static void WriteInRed(string type, string url)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("[{0}] ", type);
            Console.ResetColor();
            Console.WriteLine(url);
        }

        public static void WriteWarning(string type, string msg)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("{0}: ", type);
            Console.ResetColor();
            Console.WriteLine(msg);
        }
    }

}