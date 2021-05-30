using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http;

namespace WhatAnime_TelegramBot_.Commands.Client
{
    public class SearchAnime
    {
        public async static Task<Models.UsefullResult> ByName(string param)
        {
            HttpResponseMessage response = Connections.Find.Response("https://api.jikan.moe/v3/", "search/anime?limit=5&q=", param).Result;

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
            HttpResponseMessage response = Connections.Find.Response("https://api.jikan.moe/v3/", "anime/", param).Result;

            if (response.StatusCode != HttpStatusCode.OK)
                return null;
            string result = await response.Content.ReadAsStringAsync();

            Models.AnimeData.Root res_deserl = JsonSerializer.Deserialize<Models.AnimeData.Root>(result);
            List<string> genre = new List<string>();
            foreach (Models.AnimeData.Genre gen in res_deserl.genres)
                genre.Add(gen.name);
            Models.UsefulAnimeData use_model = new Models.UsefulAnimeData
            {
                id = res_deserl.mal_id,
                title = res_deserl.title,
                title_en = res_deserl.title_english,
                url = res_deserl.url,
                episodes = res_deserl.episodes,
                premiered = res_deserl.aired.@string,
                score = res_deserl.score,
                synopsis = res_deserl.synopsis,
                genres = String.Join(", ", genre),
                img_url = res_deserl.image_url
            };

            return use_model;
        }
        public async static Task<Models.UsefullImgData> ByImg(string param)
        {
            HttpResponseMessage response = Connections.Find.Response("https://trace.moe/api/", "search?url=", param).Result;

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            string result = await response.Content.ReadAsStringAsync();

            Models.AnimeImgData.Root res_deserl = JsonSerializer.Deserialize<Models.AnimeImgData.Root>(result);
            Models.UsefullImgData use_list = new Models.UsefullImgData();

            foreach (Models.AnimeImgData.Doc headers in res_deserl.docs)
            {
                use_list.imgDataList.Add(new Models.ImgData 
                {
                    id = headers.mal_id, 
                    title = headers.title,
                    title_en = headers.title_english
                });
            }            

            return use_list;
        }
    }
}
