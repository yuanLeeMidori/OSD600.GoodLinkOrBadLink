#### Environment Set Up

You'll need dotnet core SDK environment to use this tool and run the source code. Here is the link for download https://dotnet.microsoft.com/download. Dotnet core is available for Linux OS, macOS, and Windows. 
It is recommended to use [Visual Studio Code](https://code.visualstudio.com/download) to work on this project since most of the set-up documentations are based on thie code editor. After setup donet core in your machine, please run the `env-setup.sh` file to install the formattor and linter tool.
```
bash ./env-setup.sh
```

In Visual Studio Code, this extension is recommened to install:
[C# for Visual Studio Code (powered by OmniSharp)](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)


#### Run the Project

After cloning the repo on GitHub, change directory to it and use `dotnet run` command with the argument (e.g. file name, `--v` or `--w`) to run the project. For example, `dotnet run --w localFile.txt` or `dotnet run --v`.


#### Formate the code

This project uses [dotnet format](https://github.com/dotnet/format) to format the code. This tool should be installed by running the `env-setup.sh `. However, if the bash script fails, please execute this command:
```
dotnet tool install -g dotnet-format
```

After installing this format tool, you may use `dotnet format` command to format all the csharp file in this project. Please run this format tool before submitting your PR.

#### Resharper Linter

This project uses [Resharper](https://www.jetbrains.com/help/resharper/InspectCode.html#understanding-output) to inspect code to avoid potential errors and improve the code. This tool should be installed by running the `env-setup.sh`. However, if the bash script fails, please execute this command to install the tool:
```
dotnet tool install -g JetBrains.ReSharper.GlobalTools
```
After installing this linter tool, you may use the command below and get the analysis report in the `report.xml`.
```
jb inspectcode -o="report.xml" OSD600.GoodLinkOrBadLink.csproj
```
