using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

namespace WhatAnime_TelegramBot_.Connections
{
    public class Find
    {
        public async static Task<HttpResponseMessage> Response(string uri, string search_prefix, string search_parameter)
        {
            var baseAddress = new Uri(uri);
            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {
                var response = await httpClient.GetAsync(search_prefix + search_parameter);
                return response;
            }
        }
    }
}
