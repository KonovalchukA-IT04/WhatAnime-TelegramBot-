using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace WhatAnime_TelegramBot_.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AnimeController : ControllerBase
    {
        [HttpGet("{q}")]
        public Models.UsefullResult Name(string q)
        {
            return Commands.Client.SearchAnime.ByName(q).Result;
            //var ok = Commands.Client.SearchAnime.ByName(q);
            //if (ok.Result == null)
            //    return NotFound();
            //return Ok(ok);
        }
        [HttpGet("{id}")]
        public Models.UsefulAnimeData Id(string id)
        {
            return Commands.Client.SearchAnime.ById(id).Result;
            //var ok = Commands.Client.SearchAnime.ById(id);
            //if (ok.Result == null)
            //    return NotFound();
            //return Ok(ok);
        }
        [HttpGet]
        public Models.UsefullImgData Img(string url)
        {
            return Commands.Client.SearchAnime.ByImg(url).Result;
            //var ok = Commands.Client.SearchAnime.ByImg(url);
            //if (ok.Result == null)
            //    return NotFound();
            //return Ok(ok);
        }        
    }
}
