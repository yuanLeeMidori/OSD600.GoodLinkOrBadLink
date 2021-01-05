### GoodLinkOrBadLink

This command line tool helps you to test bundles of URLs. Just install the tool and run it with your file that contains the URLs that you're not sure which of them are valid and which of them are not.


#### Install the tool

Use this command to install the tool: 

`dotnet tool install -g OSD600.GoodLinkOrBadLink`

Use this command to install the specific version:

`dotnet tool install -g OSD600.GoodLinkOrBadLink --version <the-version-you-want>`

Use this command to upgrade to the latest version:

`dotnet tool update OSD600.GoodLinkOrBadLink -g`

Use this command to uninstall the tool:

`dotnet tool uninstall -g OSD600.GoodLinkOrBadLink`

#### How to use it

After installation, use the command `goodOrBad` as a command line tool along with a file arguement that you would like to check. For example, the file on your local machine is `urls.txt`, use the command `goodOrBad urls.txt` to run the tool. 
* Check the version of this tool with `goodOrBad --v`, `goodOrBad --version`, or `goodOrBad /v` command. 
* Check the wayback availiability with `goodOrBad --w <filename>`, `goodOrBad --wayback <filename>`, or `goodOrBad /w <filename>` command. 
* Check the output with JSON format with `goodOrBad --j <filename>`, `goodOrBad --json <filename>`, or `goodOrBad /j <filename>` command.
* Check the output with filters such as `goodOrBad --good <filename>` to get the URLs with 200 status code exclusively; `goodOrBad --bad <filename>` to get the URLs with only 400 or 404 status code; `goodOrBad --all <filename>` returns all URLs with their status code. 
* Check urls in multiple files using regex, e.g. `goodOrBad *.txt` which will check all the .txt files in the current directory. 
* Filter out specific pattern (pack the patterns within a file) with `goodOrBad --ignore <ignore_url_filename> <filename>` or `goodOrBad -i <ignore_url_filename> <filename>` or `goodOrBad /i <ignore_url_filename> <filename>` command. 
* Check the latest 10 posts from [Telescope](https://github.com/Seneca-CDOT/telescope) with `goodOrBad --t`, `goodOrBad --telescope`, or `goodOrBad /t` command. (Telescope project has to be running on the same machine.)

You can use this *goodOrBad* command in any directory. You can either move to the directory that contains the file that you want to test, or just simply use file path and run it with the command.

If the file path you're passing doesn't exist, you'll get a warning message. If the option you're passing is invalid, you'll get a short list of valid options.

#### How to contribute

Please read `CONTRIBUTING.md`.