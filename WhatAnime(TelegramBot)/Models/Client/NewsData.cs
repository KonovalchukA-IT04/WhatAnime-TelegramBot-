using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatAnime_TelegramBot_.Models
{
    public class NewsData
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Forum
        {
            public int id { get; set; }
            public int position { get; set; }
            public string name { get; set; }
            public string permalink { get; set; }
            public string url { get; set; }
        }

        public class Image
        {
            public string x160 { get; set; }
            public string x148 { get; set; }
            public string x80 { get; set; }
            public string x64 { get; set; }
            public string x48 { get; set; }
            public string x32 { get; set; }
            public string x16 { get; set; }
            public string original { get; set; }
            public string preview { get; set; }
            public string x96 { get; set; }
        }

        public class User
        {
            public int id { get; set; }
            public string nickname { get; set; }
            public string avatar { get; set; }
            public Image image { get; set; }
            public DateTime? last_online_at { get; set; }
            public string url { get; set; }
        }

        public class Linked
        {
            public int id { get; set; }
            public string name { get; set; }
            public string russian { get; set; }
            public Image image { get; set; }
            public string url { get; set; }
            public string kind { get; set; }
            public string score { get; set; }
            public string status { get; set; }
            public int episodes { get; set; }
            public int episodes_aired { get; set; }
            public string aired_on { get; set; }
            public string released_on { get; set; }
        }

        public class Root
        {
            public int id { get; set; }
            public string topic_title { get; set; }
            public string body { get; set; }
            //public string html_body { get; set; }
            //public string html_footer { get; set; }
            //public DateTime? created_at { get; set; }
            //public int comments_count { get; set; }
            //public Forum forum { get; set; }
            //public User user { get; set; }
            //public string type { get; set; }
            //public int? linked_id { get; set; }
            //public string linked_type { get; set; }
            //public Linked linked { get; set; }
            //public bool viewed { get; set; }
            //public bool last_comment_viewed { get; set; }
            //public object @event { get; set; }
            //public object episode { get; set; }
        }
    }
}
