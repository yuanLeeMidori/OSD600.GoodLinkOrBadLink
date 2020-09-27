using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace OSD600.GoodLinkOrBadLink{

    class CLIUsage{

        public static void WelcomeManual(){

            Console.WriteLine("\nThank you for using GoodLinkOrBadLink!");
            Console.WriteLine("\nRun the tool command with a file that contains URLs on your local machine and find out which are good links and which are not. For example: goodOrBad urls.txt\nUse \"goodOrBad --v\" or \"goodOrBad --version\" to get the current version of package.");

                
        }

        public static bool Version(string argument){

            string[] args = {"--v", "--version", "/v"};
            List<string> versionArgs = new List<string>(args);

            bool versionOrNot = versionArgs.Any(v => argument.Contains(v));
            if(versionOrNot){

                var versionString = Assembly.GetEntryAssembly()
                                        .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                                        .InformationalVersion
                                        .ToString();

                Console.WriteLine($"OSD600.GoodLinkOrBadLink v{versionString}");

                return true;

            }else{
                
                return false;

            }

        }
    }
}