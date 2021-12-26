# Slider

## What is this?
[Slider](https://slider.kz), a music downloading site. Aggregates several other sources for music, thses sources are unknown (but it's probably from [the russian social network VK](https://vk.com/)). The user interface is crap, but the site can be scraped.

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