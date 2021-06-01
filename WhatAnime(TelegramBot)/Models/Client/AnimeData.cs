using System;
using System.Collections.Generic;

namespace WhatAnime_TelegramBot_.Models
{
    public class AnimeData
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

        public class Aired
        {
            public string @string { get; set; }
        }

        public class Genre
        {
            public int mal_id { get; set; }
            public string type { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Root
        {
            public int mal_id { get; set; }
            public string url { get; set; }
            public string image_url { get; set; }
            public string title { get; set; }
            public string title_english { get; set; }
            public int? episodes { get; set; }
            public Aired aired { get; set; }
            public double? score { get; set; }
            public string synopsis { get; set; }
            public List<Genre> genres { get; set; }
        }
    }
}
