# Slider

## What is slider?
[Slider](https://slider.kz), a music downloading site. Aggregates several other sources for music, thses sources are unknown (but it's probably from [the russian social network VK](https://vk.com/), they have a music streaming service). The user interface is crap, but the site can be scraped.

## Terminology
* `audios`, an array of several tracks.
* `id` used to identify the track in slider, does not change.
* `duration`, lenght of the track in seconds.
* `tit_art` is the track main artist and the track title seperated by an `-`, keep this [url encoded](https://www.urlencoder.org/) when working with requests.
* `url`, some kind of internal URI. Seems related to `vkuseraudio.net` (by VK) [explore here at subdomainfinder](https://subdomainfinder.c99.nl/scans/2020-08-27/vkuseraudio.net).
* `extra` is always null. Don't know what it is.

## API
### Search
Request as HTTP GET: [https://slider.kz//vk_auth.php?q=avicii](https://slider.kz//vk_auth.php?q=avicii)

Response formatted as JSON:
```
{
  "audios": {
    "": [
      {
        "id": "371745454_456513492",
        "duration": 247,
        "tit_art": "Avicii - Wake Me Up",
        "url": "cs3-2v4/s/v1/acmp/nzfrT3Y6NgVWEtXLZC1Y7OZZ6nK54D0FUy35Co_kBAmDtIh_8tjw7O6p8IsYiG4EV3oP1C0sDRXqxfDQEB1fRXFrWX7jak23rSZI1NrbPYlKFpCXu1HG6prKmA59OXq9kqKlulMqE5_d",
        "extra": null
      }
    ]
  }
}
```
*The query parameter `q` can be [url encoded](https://www.urlencoder.org/), for example `q=Avicii - Wake Me Up` can be sent as `q=Avicii%20-%20Wake%20Me%20Up`.*

### Download track
Request as HTTP GET: [https://slider.kz/download/371745454_456513492/247/cs3-2v4/s/v1/acmp/nzfrT3Y6NgVWEtXLZC1Y7OZZ6nK54D0FUy35Co_kBAmDtIh_8tjw7O6p8IsYiG4EV3oP1C0sDRXqxfDQEB1fRXFrWX7jak23rSZI1NrbPYlKFpCXu1HG6prKmA59OXq9kqKlulMqE5_d/Avicii%20-%20Wake%20Me%20Up.mp3](https://slider.kz/download/371745454_456513492/247/cs3-2v4/s/v1/acmp/nzfrT3Y6NgVWEtXLZC1Y7OZZ6nK54D0FUy35Co_kBAmDtIh_8tjw7O6p8IsYiG4EV3oP1C0sDRXqxfDQEB1fRXFrWX7jak23rSZI1NrbPYlKFpCXu1HG6prKmA59OXq9kqKlulMqE5_d/Avicii%20-%20Wake%20Me%20Up.mp3), path structued as `/download/` + **id** + `/` + **duration** + `/` + **url** + `/` + **tit_art** ([url encoded](https://www.urlencoder.org/)) + .mp3.

Response as file with filename **tit-art** + `[www.slider.kz]`, example `Avicii - Wake Me Up [www.slider.kz].mp3`.

*All bold names are from the above API -> Search response.*

### Similar artists
Request as HTTP GET: [https://slider.kz/similar/artist/Tim%20Berg](https://slider.kz/similar/artist/Tim%20Berg), where `Tim%20Berg` is the artist [url encoded](https://www.urlencoder.org/) (*Tim Berg*).

Response formatted as JSON:
```
{
  "similarartists": {
    "artist": [
      {
        "name": "Avicii",
        "mbid": "c85cfd6b-b1e9-4a50-bd55-eb725f04f7d5",
        "match": "1",
        "url": "https://www.last.fm/music/Avicii",
        "image": DISREGARD
        ],
        "streamable": "0"
      }
    ],
    "@attr": {
      "artist": "Tim Berg"
    }
  }
}
```
Note that **image** is marked as DISREGARD, thats becouse it does not matter. The field **@attr** -> **artist** is just the requested artists name.

The array **artist** (in **similarartists**) contains artists that the service beleive are related to your request, **match** is a float from `0` to `1` that indicates the relationship. In this example *Tim Berg* and *Avicii* have an absolute relationship (of `1`), becouse they are the same person.

The **url** ([https://www.last.fm/music/Avicii](https://www.last.fm/music/Avicii)) contains a lot of metadata for the artist. This may be integrated in the future. Don't trust this site for top played tracks, it's top 10 does not seems to be that accurate.

### Reversing VK
MP3 downloads from [VK/VKontakte](https://en.wikipedia.org/wiki/VK_(service)) look very similar to slider's downloads. Sliders backend have to use VK as a repository. Here are some examples of VK audio download links. Note that these links have already been [url decoded](https://www.urldecoder.org/).
- `https://cs3-1v4.vkuseraudio.net/p2/c49f9ece675317.mp3?extra=hDmOUgRWCu_tTz7OLYqsZUCCeqG9FiVLkvFTaJUDmYQqDJqeB7iW9hcrH2-XRg4UkYpFg4IqNLNrmP2tiwlBtYsUkfP6nLQ-kogH3fVylbunHL2LBIV8wf2p2ueOlno6GVn9yxMYi4EGeAz3orPFW1I&long_chunk=1&cc_key=`
- `https://cs3-6v4.vkuseraudio.net/p1/04ef07876b9289.mp3?extra=sD9GKkqjitNS83awImyVUJZCMOmOYSvg-xLJvLWZj43VvRuBPaMMbfziCrAtre_I2WbhBWYIPPh9vV4gEfX93sYYtww1lmN66lY7RwFPJWrzctXDSnXQdqlTUbnofP-fwXuJdObJEu0C-CJXdpZ6K4A&long_chunk=1&cc_key=`
- `https://cs3-5v4.vkuseraudio.net/p3/f67cd2fa9c29f6.mp3?extra=V_r_HxFZSiIlKr5RBTCb307xBfpgdk_gy9cSZGa1qCb0_6CBitdni0eMx7gzCGbAHxEOl_YYbv5-yovK7WPOPQF7iHMm1Z0QBuVRFGTKZec2FnbIZc3bx0aIJ4MQLVB1n1NjbvnWpcrUmGn2gNFwOsY&long_chunk=1&cc_key=`
This repo may be a good place to start for inspiration [python273/vk_api](https://github.com/python273/vk_api) or maybe this blog [Four ways to get VK audio or "this is not a bug, but a feature](https://itnan.ru/post.php?c=1&p=519302).
