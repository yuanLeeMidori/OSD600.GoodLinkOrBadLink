using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace OSD600.GoodLinkOrBadLink
{
    class CLIUsage
    {
        public static void WelcomeManual()
        {
            Console.WriteLine("\nThank you for using GoodLinkOrBadLink!");
            Console.WriteLine("\nRun the tool command with a file that contains URLs on your local machine and find out which are good links and which are not. For example: goodOrBad urls.txt" +
            "\nYou can also add options to run with your file." +
            "\n\nUse \"goodOrBad --v\" or \"goodOrBad --version\" to get the current version of package." +
            "\nUse \"goodOrBad --w\" or \"goodOrBad --wayback\" to check Wayback machine's availability." +
            "\nUse \"goodOrBad --good\" to get URLs with status code 200." +
            "\nUse \"goodOrBad --bad\" to get URLs with status code 400 or 404." +
            "\nUse \"goodOrBad --all\" to get all URLs." +
            "\nUse \"goodOrBad --j\" or \"goodOrBad --json\" or \"goodOrBad /j\" to get JSON format output." +
            "\nUse \"goodOrBad *.txt\" to pass multiple files. " +
            "\nUse \"goodOrBad --t\" or \"goodOrBad --telescope\" to check the latest 10 posts from Telescope.");
        }

        public static bool isOption(string argument)
        {
            if (argument.StartsWith("--") || argument.StartsWith("/"))
            {
                if (!Version(argument) && !WayBack(argument) && !JSON(argument) && !Filter(argument) && !Ignore(argument) && !Telescope(argument))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        public static bool Version(string argument)
        {
            string[] args = { "--v", "--version", "/v" };
            List<string> versionArgs = new List<string>(args);
            bool versionOrNot = versionArgs.Any(v => argument.Contains(v));
            if (versionOrNot)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool WayBack(string argument)
        {
            string[] args = { "--w", "--wayback", "/w" };
            List<string> waybackList = new List<string>(args);
            bool wayback = waybackList.Any(w => argument.Contains(w));
            if (wayback)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool GlobalPattern(string argument)
        {
            bool gp = false;
            string path = Directory.GetCurrentDirectory();
            try
            {
                string[] fileNames = Directory.GetFiles(path, argument);
                if (fileNames.Length > 0)
                {
                    gp = true;
                }
            }
            catch (Exception)
            {
                gp = false;
            }
            return gp;
        }

        public static bool JSON(string argument)
        {
            string[] args = { "-j", "--json", "/j" };
            List<string> jsonArgs = new List<string>(args);
            bool jsonOrNot = jsonArgs.Any(j => argument.Contains(j));
            if (jsonOrNot)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool Filter(string argument)
        {
            string[] args = { "--good", "--bad", "--all" };
            List<string> filterArgs = new List<string>(args);
            bool filterOrNot = filterArgs.Any(f => argument.Contains(f));
            if (filterOrNot)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool Ignore(string argument)
        {
            string[] args = { "-i", "--ignore", @"\i" };
            List<string> ignoreArgs = new List<string>(args);
            bool ignoreOrNot = ignoreArgs.Any(f => argument.Contains(f));
            if (ignoreOrNot)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool Telescope(string argument)
        {
            string[] args = { "-t", "--telescope", @"\t" };
            List<string> teleArgs = new List<string>(args);
            bool telescopeOrNot = teleArgs.Any(t => argument.Contains(t));
            if (telescopeOrNot)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}