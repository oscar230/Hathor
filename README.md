# Hathor
A music tool! (and also [a goddess](https://en.wikipedia.org/wiki/Hathor), ooOooO!).

<img src="https://upload.wikimedia.org/wikipedia/commons/thumb/4/47/Hathor.svg/440px-Hathor.svg.png" alt="A image of Hathor, a ancient Egyptian godess with a red dress and blue hair, holding a cane." width="100vw"/>

## Using Hathor
See [releases](https://github.com/oscar230/hathor/releases), choose the latest one and follow the instruction.

## Contribute
* See [issues on Github](https://github.com/oscar230/hathor/issues) for any open issues, any help is welcomed!
For file names and directories consider using [Unix File Naming Practices](https://www.december.com/unix/tutor/filenames.html) except for in `WebApi` where [.NET General Naming Conventions](https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/general-naming-conventions) are prefered.

### Analysis
* Analyse network traffic using [Thunder Client by Ranga Vadhineni](https://marketplace.visualstudio.com/items?itemName=rangav.vscode-thunder-client) avaliable in VSCode. Store analytics in the `docs` directory.

### Backend API
Using a ASP .NET Core 5.0 backend located in `WebApi`.

### Frontend Web
* Using a web frontend located in `WebUI`.
  * You do not need to open the [Solution (.sln) file](https://docs.microsoft.com/en-us/visualstudio/extensibility/internals/solution-dot-sln-file?view=vs-2022) to develop the frontend, altough it is included in the sulution for the backend developers using Visual Studio.
* Target browsers, latest stable version of chrome/[chromium](https://www.chromium.org/).
* **Need help to get rolling?** Why not use [Material UI](https://mui.com/) along with [Svelte](https://svelte.dev/), or maybe cool [Blazor](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor) by Microsoft with all new fresh and cool [Havit](https://havit.blazor.eu/).

## Build
* **Backend**: open [Solution (.sln) file](https://docs.microsoft.com/en-us/visualstudio/extensibility/internals/solution-dot-sln-file?view=vs-2022) using [Visual Studio (2022 Community is recommended)](https://visualstudio.microsoft.com/).
  * If you're compiling the backend on UNIX (mac/linux) consider checking out how to use the [ASP.NET Core command line](https://dotnet.microsoft.com/en-us/learn/aspnet/what-is-aspnet-core).
  * If you only want to run and not develop the backend, see [the releases page](https://github.com/oscar230/hathor/releases) or build a quick mock API using [Beeceptor](https://beeceptor.com/).
* **Frontend**: _TODO_

## Legal & Complaints
Complaints and legal considerations are directed to [github/oscar230](https://github.com/oscar230), the email is in the section to the left.

### Dependencies
* The user agents located at [`\hathor\WebApi\Resources\UserAgents\`](https://github.com/oscar230/hathor/tree/main/WebApi/Resources/UserAgents) are from [tamimibrahim17/List-of-user-agents](https://github.com/tamimibrahim17/List-of-user-agents) repo, at [commit 0f5e980e898054d8b769dd17b1db0c1c429e5e37](https://github.com/tamimibrahim17/List-of-user-agents/commit/0f5e980e898054d8b769dd17b1db0c1c429e5e37) where the content was licenced under MIT license, as seen in [this LICENSE file](https://github.com/tamimibrahim17/List-of-user-agents/commit/d6358528c91b21656597072b8f61a1b2a9224aba).
  * Read the MIT license more [here](https://en.wikipedia.org/wiki/MIT_License).
