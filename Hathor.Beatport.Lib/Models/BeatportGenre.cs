﻿using Hathor.Common.Models;
using HtmlAgilityPack;

namespace Hathor.Beatport.Lib.Models
{
    internal class BeatportGenre
    {
        internal int Id { get; set; }
        internal string? Name { get; set; }
        internal Uri? Url { get; set; }

        public BeatportGenre(HtmlDocument htmlDocument, Uri uri)
        {
            throw new NotImplementedException();
        }

        public BeatportGenre(HtmlNode node, Uri uri)
        {
            string href = node.Attributes["href"].Value;
            string subGenre = node.Attributes["data-name"].Value;
            string subGenreId = href.Split('/').Last();
            Id = int.Parse(subGenreId);
            Name = subGenre;
            Url = new Uri(uri, href);
        }

        internal Genre ToGenre()
        {
            return new Genre()
            {
                Uri = Url,
                Title = Name,
            };
        }

        public override string? ToString() => Name;
    }
}
