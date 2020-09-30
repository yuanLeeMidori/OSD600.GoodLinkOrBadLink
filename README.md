### GoodLinkOrBadLink

This command line tool helps you to test bundles of URLs. Just install the tool and run it with your file that contains the URLs that you're not sure which of them are valid and which of them are not.

#### Environment

You'll need dotnet core SDK environment to use this tool and run the source code. Here is the link for download https://dotnet.microsoft.com/download. Dotnet core is available for Linux OS, macOS, and Windows. 


#### Install the tool

Use this command to install the tool: 

`dotnet tool install -g OSD600.GoodLinkOrBadLink`

Use this command to install the specific version:

`dotnet tool install -g OSD600.GoodLinkOrBadLink --version *the-version-you-want*`

Use this command to upgrade to the latest version:

`dotnet tool update OSD600.GoodLinkOrBadLink -g`

Use this command to uninstall the tool:

`dotnet tool uninstall -g OSD600.GoodLinkOrBadLink`

#### How to use it

After installation, use the command `goodOrBad` as a command line tool along with a file arguement that you would like to check. For example, the file on your local machine is `urls.txt`, use the command `goodOrBad urls.txt` to run the tool. You can also check the version of this tool with `goodOrBad --v` or `goodOrBad --version` command. 

You can use this *goodOrBad* command in any directory. You can either move to the directory that contains the file that you want to test, or just simply use file path and run it with the command.

If the argument you're passing with the command is not valid, you'll get a warning message.


#### Run the source code

After cloning the repo on GitHub, change directory to it and use `dotnet run` with the argument (e.g. file name, --v/--version) to run the Program.cs. For example, `dotnet run localFile.txt`. Or you can download the source code and use IDE such as Visual Studio to run the project. 

