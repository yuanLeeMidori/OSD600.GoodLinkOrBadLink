using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;


namespace OSD600.GoodLinkOrBadLink{

    class CLIUsage{

        public static void WelcomeManual(){

            Console.WriteLine("\nThank you for using GoodLinkOrBadLink!");
            Console.WriteLine("\nRun the tool command with a file that contains URLs on your local machine and find out which are good links and which are not. For example: goodOrBad urls.txt" + 
            "\nUse \"goodOrBad --v\" or \"goodOrBad --version\" or \"goodOrBad /v\" to get the current version of package." +
            "\nUse \"goodOrBad --w\" or \"goodOrBad --wayback\" or \"goodOrBad /w\" to check Wayback machine's availability." +
            "\nUse \"goodOrBad --j\" or \"goodOrBad --json\" or \"goodOrBad /j\" to get JSON format output." + 
            "\nUse to \"goodOrBad *.txt\" to pass multiple files. ");

                
        }

        public static bool isOption(string argument){

            if(argument.StartsWith("--") || argument.StartsWith("/")){

                if(!Version(argument) && !WayBack(argument) && !JSON(argument)){

                    return false;

                }else{

                    return true;

                }

            
            }else{

                return true;
                
            }

        }

        public static bool Version(string argument){

            string[] args = {"--v", "--version", "/v"};
            List<string> versionArgs = new List<string>(args);

            bool versionOrNot = versionArgs.Any(v => argument.Contains(v));
            if(versionOrNot){

                return true;

            }else{
                
                return false;

            }

        }

        public static bool WayBack(string argument){

            string[] args = {"--w", "--wayback", "/w"};
            List<string> waybackList = new List<string>(args);

            bool wayback = waybackList.Any(w => argument.Contains(w));

            if(wayback){

                return true;
                
            }else{
                
                return false;

            }
        }

        public static bool GlobalPattern(string argument){

            bool gp = false;
            string path = Directory.GetCurrentDirectory();

            try{

                string[] fileNames = Directory.GetFiles(path, argument);
                if (fileNames.Length > 0)
                {
                    gp = true;

                }
            }
            catch (Exception){

                gp = false;

            }

            return gp;
        }

        public static bool JSON(string argument){

            string[] args = {"-j", "--json", "/j"};
            List<string> jsonArgs = new List<string>(args);

            bool jsonOrNot = jsonArgs.Any(j => argument.Contains(j));
            if(jsonOrNot){

                return true;

            }else{

                return false;

            }
            
        }

    }
}