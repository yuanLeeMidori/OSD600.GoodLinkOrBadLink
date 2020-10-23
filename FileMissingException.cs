using System;

namespace OSD600.GoodLinkOrBadLink {

    [Serializable]
    public class FileMissingException : Exception {

        public FileMissingException() {
            Console.WriteLine("Missing file.");
            System.Environment.Exit(1);
        }

        public FileMissingException(string message) : base(message){
            Console.WriteLine("Missing file input, {0} option requires one input file.", message);
            System.Environment.Exit(1);
        }

        public FileMissingException(string option, string fileNumber) {
            Console.WriteLine("\"Missing file input\" or \"too many file input\", {0} option requires {1} input file(s)", option, fileNumber );
            System.Environment.Exit(1);
        }

    }

}