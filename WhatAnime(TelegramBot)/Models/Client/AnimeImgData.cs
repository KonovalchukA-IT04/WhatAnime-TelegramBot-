using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatAnime_TelegramBot_.Models
{
    public class AnimeImgData
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Doc
        {
            public int mal_id { get; set; }
            public string title { get; set; }
            public string? title_english { get; set; }
        }

        public class Root
        {
            public List<Doc> docs { get; set; }
        }
    }
}
