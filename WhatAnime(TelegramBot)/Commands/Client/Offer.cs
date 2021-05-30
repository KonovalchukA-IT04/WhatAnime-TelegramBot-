using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace WhatAnime_TelegramBot_.Commands.Client
{
    public class Offer
    {
        public async static Task<Models.ShortData> Make(Models.AnimeToList titles)
        {
            string list = titles.name;
            string[] ar = list.Split('\n');
            Random random = new Random();
            bool f = true;
            int i = 0;
            System.Net.Http.HttpResponseMessage response = null;
            while (f)
            {
                i = random.Next(0, ar.Length);
                response = Connections.Find.Response("https://api.jikan.moe/v3/", "search/anime?q=", ar[i]).Result;

                if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                    f = false;
            }
            string result = await response.Content.ReadAsStringAsync();
            Models.SearchResult.Root res_deserl = JsonSerializer.Deserialize<Models.SearchResult.Root>(result);
            
            response = Connections.Find.Response("https://api.jikan.moe/v3/", "anime/", Convert.ToString(res_deserl.results[0].mal_id)).Result;
            result = await response.Content.ReadAsStringAsync();
            Models.AnimeData.Root res_deserl_anime = JsonSerializer.Deserialize<Models.AnimeData.Root>(result);
            Models.AnimeData.Genre[] k = res_deserl_anime.genres.ToArray();
            i = random.Next(0, k.Length);
            int g = k[i].mal_id;

            response = Connections.Find.Response("https://api.jikan.moe/v3/", "search/anime?genre=", Convert.ToString(g)).Result;
            result = await response.Content.ReadAsStringAsync();

            Models.SearchResult.Root res = JsonSerializer.Deserialize<Models.SearchResult.Root>(result);

            Models.UsefullResult use_list = new Models.UsefullResult();

            foreach (Models.SearchResult.Result headers in res.results)
            {
                use_list.dataList.Add(new Models.ShortData { id = headers.mal_id, title = headers.title, url = headers.url });
            }            

            Models.ShortData[] use_it = use_list.dataList.ToArray();
            i = random.Next(0, use_it.Length);
            Models.ShortData goodchoise = use_it[i];

            return goodchoise;
        }
    }
}
