using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http;

namespace WhatAnime_TelegramBot_.Commands.Client
{
    public class SearchManga
    {
        public async static Task<Models.UsefullResult> ByName(string param)
        {
            HttpResponseMessage response = Connections.Find.Response("https://api.jikan.moe/v3/", "search/manga?limit=5&q=", param).Result;

            if (response.StatusCode != HttpStatusCode.OK)
                return null;
            string result = await response.Content.ReadAsStringAsync();

            Models.SearchResult.Root res_deserl = JsonSerializer.Deserialize<Models.SearchResult.Root>(result);

            Models.UsefullResult use_list = new Models.UsefullResult();

            foreach (Models.SearchResult.Result headers in res_deserl.results)
            {
                use_list.dataList.Add(new Models.ShortData
                { 
                    id = headers.mal_id,
                    title = headers.title,
                    url = headers.url
                });
            }

            return use_list;
        }
        public async static Task<Models.UsefulAnimeData> ById(string param)
        {
            HttpResponseMessage response = Connections.Find.Response("https://api.jikan.moe/v3/", "manga/", param).Result;

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            string result = await response.Content.ReadAsStringAsync();

            Models.MangaData.Root res_deserl = JsonSerializer.Deserialize<Models.MangaData.Root>(result);
            List<string> genre = new List<string>();
            foreach (Models.MangaData.Genre gen in res_deserl.genres)
                genre.Add(gen.name);

            Models.UsefulAnimeData use_list = new Models.UsefulAnimeData
            {
                id = res_deserl.mal_id,
                title = res_deserl.title,
                title_en = res_deserl.title_english,
                url = res_deserl.url,
                episodes = res_deserl.chapters,
                premiered = res_deserl.published.@string,
                score = res_deserl.score,
                synopsis = res_deserl.synopsis,
                genres = String.Join(", ", genre),
                img_url = res_deserl.image_url
            };

            return use_list;
        }
    }
}
