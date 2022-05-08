# Hathor
<img src="https://upload.wikimedia.org/wikipedia/commons/thumb/4/47/Hathor.svg/440px-Hathor.svg.png" alt="A image of Hathor, a ancient Egyptian godess with a red dress and blue hair, holding a cane." width="30vw"/>

[![Build Status](https://drone.wonky.se/api/badges/oscar230/Hathor/status.svg)](https://drone.wonky.se/oscar230/Hathor)

## Using Hathor
See [releases](https://github.com/oscar230/hathor/releases), choose the latest one and follow the instruction.
If you're ecnountering problems with exporting Rekordbox's collection as XML, see [this thread over at Denons forums](https://community.enginedj.com/t/no-more-xml-export-in-rekordbox-6-blocks-denon-prime-users-to-access-their-rekordbox-collection/21170/51), for some reason this conversation isn't happening at Pioneers forum.

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

## Reverse engineering Slider
The retrieved audio object from [slider.kz](https://slider.kz/) looks like this:
```
    {
    "id": "474499262_456418441",
    "duration": 244,
    "tit_art": "Avicii - Wake Me Up",
    "url": "cs3-1v4\/s\/v1\/acmp\/vFxhRpwgHfGur5nMIeD8auzTVCKQk1rx_nHYTELXjanSlncxhlFAnevtNYiQKLRC__717Y04FP26rxpG7vkcYV1ArQEz72-Jr1GyPUnOHNrZJlS5mb-FhA6wU7rvX4TgE0jQxZ2Rjojf-b3go_CbWDXa1ersAVERwMycpMAgrQlFbKTk6g",
    "extra": null
    }
```
To create a download link format the url as such `https://slider.kz/download/474499262_456418441/244/cs3-1v4/s/v1/acmp/vFxhRpwgHfGur5nMIeD8auzTVCKQk1rx_nHYTELXjanSlncxhlFAnevtNYiQKLRC__717Y04FP26rxpG7vkcYV1ArQEz72-Jr1GyPUnOHNrZJlS5mb-FhA6wU7rvX4TgE0jQxZ2Rjojf-b3go_CbWDXa1ersAVERwMycpMAgrQlFbKTk6g/Avicii%20-%20Wake%20Me%20Up.mp3?extra=null`, it's the format `https://slider.kz/download/`**id**`/`**duration**`/`**url**`/`**tit_art**`.mp3?extra=`**extra**. Its a good idea to [url encode](https://docs.microsoft.com/en-us/dotnet/api/system.web.httputility.urlencode?view=net-6.0) the paramters, especially the **tit_art** since it will include _spaces_.
### Is Slider VK?
MP3 downloads from [VK/VKontakte](https://en.wikipedia.org/wiki/VK_(service)) look very similar to slider's downloads. Sliders backend have to use VK as a repository. Here are some examples of VK audio download links. Note that these links have already been [url decoded](https://www.urldecoder.org/).
- `https://cs3-1v4.vkuseraudio.net/p2/c49f9ece675317.mp3?extra=hDmOUgRWCu_tTz7OLYqsZUCCeqG9FiVLkvFTaJUDmYQqDJqeB7iW9hcrH2-XRg4UkYpFg4IqNLNrmP2tiwlBtYsUkfP6nLQ-kogH3fVylbunHL2LBIV8wf2p2ueOlno6GVn9yxMYi4EGeAz3orPFW1I&long_chunk=1&cc_key=`
- `https://cs3-6v4.vkuseraudio.net/p1/04ef07876b9289.mp3?extra=sD9GKkqjitNS83awImyVUJZCMOmOYSvg-xLJvLWZj43VvRuBPaMMbfziCrAtre_I2WbhBWYIPPh9vV4gEfX93sYYtww1lmN66lY7RwFPJWrzctXDSnXQdqlTUbnofP-fwXuJdObJEu0C-CJXdpZ6K4A&long_chunk=1&cc_key=`
- `https://cs3-5v4.vkuseraudio.net/p3/f67cd2fa9c29f6.mp3?extra=V_r_HxFZSiIlKr5RBTCb307xBfpgdk_gy9cSZGa1qCb0_6CBitdni0eMx7gzCGbAHxEOl_YYbv5-yovK7WPOPQF7iHMm1Z0QBuVRFGTKZec2FnbIZc3bx0aIJ4MQLVB1n1NjbvnWpcrUmGn2gNFwOsY&long_chunk=1&cc_key=`
This repo may be a good place to start for inspiration [python273/vk_api](https://github.com/python273/vk_api) or maybe this blog [Four ways to get VK audio or "this is not a bug, but a feature](https://itnan.ru/post.php?c=1&p=519302).
**TODO: Download directly from VK.**
