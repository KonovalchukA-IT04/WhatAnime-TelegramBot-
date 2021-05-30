using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatAnime_TelegramBot_.Models
{
    public class MangaData
    {// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

        public class Published
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
            public string title { get; set; }
            public string title_english { get; set; }
            public string image_url { get; set; }
            public object volumes { get; set; }
            public int? chapters { get; set; }
            public Published published { get; set; }
            public double? score { get; set; }
            public string synopsis { get; set; }
            public List<Genre> genres { get; set; }
        }
    }
}
