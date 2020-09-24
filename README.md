### GoodLinkOrBadLink

This command line tool helps you to test bundle of URLs. Just install the tool and run it with your file that contains the URLs that you're not sure which of them are valid and which of them are not.

#### Environment

You'll need dotnet core SDK environment to use this tool and run the source code. Here is the link for download https://dotnet.microsoft.com/download. Dotnet core is available for Linux OS, macOS, and Windows. 


#### Install the tool

Use this command to install the tool: 

`dotnet tool install --global OSD600.GoodLinkOrBadLink --version 1.0.2`

After the installation, use the command `goodOrBad` as tool name with the file that you want to check. For example, the file on your local machine is `urls.txt`, use command `goodOrBad urls.txt` to run the tool. You can also check the version of this tool with `goodOrBad --v` or `goodOrBad --version` command. 

#### Run the source code

After cloning the repo, change directory to it and use `dotnet run` with argumens (e.g. file name, --v/--version) to run the Program.cs. Or you can use other IDE to run the project. 

