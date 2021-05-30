using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net;

namespace WhatAnime_TelegramBot_.Commands.Client
{
    public class Others
    {
        public async static Task<Models.Quotes> SearchQuote()
        {
            HttpResponseMessage response = Connections.Find.Response("https://animechan.vercel.app/api/", "random", "").Result;

            if (response.StatusCode != HttpStatusCode.OK)
                return null;
            string result = await response.Content.ReadAsStringAsync();
            Models.Quotes quotes = JsonSerializer.Deserialize<Models.Quotes>(result);

            return quotes;
        }
        public async static Task<Models.News> SearchNews()
        {
            HttpResponseMessage response = Connections.Find.Response("https://shikimori.one/api/", "topics?forum=news", "").Result;
            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            string result = await response.Content.ReadAsStringAsync();
            List<Models.NewsData.Root> raw_news = JsonSerializer.Deserialize<List<Models.NewsData.Root>>(result);

            Models.News use_list = new Models.News();

            foreach (Models.NewsData.Root headers in raw_news)
            {
                use_list.newsList.Add(new Models.UsefullNewsData 
                { 
                    title = headers.topic_title,
                    body = Help_tools.Help_meth.QuotesRemover(headers.body),
                    url_ById = $"https://shikimori.one/forum/{headers.id}"
                });
            }

            return use_list;
        }
    }
}
