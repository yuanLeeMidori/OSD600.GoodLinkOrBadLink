#### Environment Set Up

You'll need dotnet core SDK environment to use this tool and run the source code. Here is the link for download https://dotnet.microsoft.com/download. Dotnet core is available for Linux OS, macOS, and Windows. 
It is recommended to use [Visual Studio Code](https://code.visualstudio.com/download) to work on this project since most of the set-up documentations are based on thie code editor. 

In Visual Studio Code, this extension is recommened to install:
[C# for Visual Studio Code (powered by OmniSharp)](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)


#### Run the Project

After cloning the repo on GitHub, change directory to it and use `dotnet run` command with the argument (e.g. file name, `--v` or `--w`) to run the project. For example, `dotnet run --w localFile.txt` or `dotnet run --v`.


#### Formate the code

This project uses [dotnet format](https://github.com/dotnet/format) to format the code. To install this format tool, go to the root of the project (`<userdata>/OSD600.GoodLinkOrBadLink`) and execute this command:
```
dotnet tool install -g dotnet-format
```

After installing this format tool, you may use `dotnet format` command to format all the csharp file in this project. Please run this format tool before submitting your PR.