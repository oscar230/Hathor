# Hathor
<img src="https://upload.wikimedia.org/wikipedia/commons/thumb/4/47/Hathor.svg/440px-Hathor.svg.png" alt="A image of Hathor, a ancient Egyptian godess with a red dress and blue hair, holding a cane." width="30vw"/>
Hathor contains a number of projects aiming to help DJs aquire, analyze and manage music.

## Concept architecture
Note that this may change.

![A diagram representing the concept architecture of this project.](https://github.com/oscar230/Hathor/blob/main/docs/concept.drawio.png?raw=true)

## Using withput building binaries
Console applications are avaliable, these can be used locally.
See [releases](https://github.com/oscar230/hathor/releases), choose the latest one and follow the instruction.
### Problems with Rekordbox?
If you're encnountering problems with exporting Rekordbox's collection as XML, see [this thread over at Denons forums](https://community.enginedj.com/t/no-more-xml-export-in-rekordbox-6-blocks-denon-prime-users-to-access-their-rekordbox-collection/21170/51), for some reason this conversation isn't happening at Pioneers forum.
### Dependencies
Requires [.NET Runtime 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) for all console apps.

## Contributing to the code
* See [issues on Github](https://github.com/oscar230/hathor/issues) for any open issues, any help is welcomed!
* Please follow [.NET General Naming Conventions](https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/general-naming-conventions).
* You need to be able to open SLN-sultions.

## Building binaries
* **Backend**: open [Solution (.sln) file](https://docs.microsoft.com/en-us/visualstudio/extensibility/internals/solution-dot-sln-file?view=vs-2022) using [Visual Studio (2022 Community is recommended)](https://visualstudio.microsoft.com/).
  * If you're compiling the backend on UNIX (mac/linux) consider checking out how to use the [ASP.NET Core command line](https://dotnet.microsoft.com/en-us/learn/aspnet/what-is-aspnet-core).
  * If you only want to run and not develop the backend, see [the releases page](https://github.com/oscar230/hathor/releases) or build a quick mock API using [Beeceptor](https://beeceptor.com/).
* **Frontend**: _TODO_

## Legal, complaints dependencies
- Complaints and legal considerations are directed to [github/oscar230](https://github.com/oscar230), the email is in the section to the left.
- The user agents located at [`\hathor\WebApi\Resources\UserAgents\`](https://github.com/oscar230/hathor/tree/main/WebApi/Resources/UserAgents) are from [tamimibrahim17/List-of-user-agents](https://github.com/tamimibrahim17/List-of-user-agents) repo, at [commit 0f5e980e898054d8b769dd17b1db0c1c429e5e37](https://github.com/tamimibrahim17/List-of-user-agents/commit/0f5e980e898054d8b769dd17b1db0c1c429e5e37) where the content was licenced under MIT license, as seen in [this LICENSE file](https://github.com/tamimibrahim17/List-of-user-agents/commit/d6358528c91b21656597072b8f61a1b2a9224aba).
  - Read the MIT license more [here](https://en.wikipedia.org/wiki/MIT_License).
