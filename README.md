### GoodLinkOrBadLink

This command line tool helps you to test bundles of URLs. Install the tool and run it with your file that contains the URLs that you're not sure which of them are valid and which of them are not.


#### Install the tool

Use this command to **install** the tool: 

`dotnet tool install -g OSD600.GoodLinkOrBadLink`

Use this command to install the **specific version**:

`dotnet tool install -g OSD600.GoodLinkOrBadLink --version <the-version-you-want>`

Use this command to **upgrade to the latest** version:

`dotnet tool update OSD600.GoodLinkOrBadLink -g`

Use this command to **uninstall** the tool:

`dotnet tool uninstall -g OSD600.GoodLinkOrBadLink`

#### How to use it

After installation, use the command `goodOrBad` as a command line tool along with a file arguement that you would like to check. For example, the file that contains URLs that you want to check on your local machine is `urls.txt`, use the command `goodOrBad urls.txt` to run the tool.

|Functionality | Option name    | Example | Precondition |
| :---------|:-----------|:--------|:------|
|Get current version| `--v`, `--version`, `/v` | `goodOrBad --version` | |
|Check wayback | `--w`, `--wayback`, `/w` | `goodOrBad /w <filename>` | |
|JSON output | `--j`, `--json`, `/j` | `goodOrBad --j <filename>` | |
|Status code 200 only | `--good` | `goodOrBad --good <filename>` | |
|Status code 400/404 only | `--bad` | `goodOrBad --bad <filename>`| |
|Include all result | `--all`, empty | `goodOrBad <filename>` or `goodOrBad --all <filename>` | |
|Pass multiple files | N/A, use regex on file name | `goodOrBad *.txt` checks all txt file in the directory | |
|Ignore specific pattern | `--i`, `--ignore`, `/i` | `goodOrBad --i <ignore_url_filename> <filename>` |Place the URL patterns that you want to filter out in the `<ignore_url_filename>`. For example, put `http://www.wiki` in the `<ignore_url_file>` will exclude all URLs that starts with `http://www.wiki`.|
|Check latest 10 posts on [Telescope](https://github.com/Seneca-CDOT/telescope) | `--t`, `--telescope`, `/t` | `goodOrBad --t` | Telescope project has to be running on the same machine. |

You can use this *goodOrBad* command in any directory. You may either move to the directory that contains the file that you want to test, or just simply use file path and run it with the command.

If the file path you're passing doesn't exist, you'll get a warning message. If the option you're passing is invalid, you'll get a short list of valid options.


#### How to contribute

Please read `CONTRIBUTING.md`.
