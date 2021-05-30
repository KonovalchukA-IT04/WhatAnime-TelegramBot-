using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatAnime_TelegramBot_.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MangaController : ControllerBase
    {
        [HttpGet("{q}")]
        public Models.UsefullResult Name(string q)
        {
            return Commands.Client.SearchManga.ByName(q).Result;
            //var ok = Commands.Client.SearchManga.ByName(q);
            //if (ok.Result == null)
            //    return NotFound();
            //return ok.Result;
        }
        [HttpGet("{id}")]
        public Models.UsefulAnimeData Id(string id)
        {
            return Commands.Client.SearchManga.ById(id).Result;
            //var ok = Commands.Client.SearchManga.ById(id);
            //if (ok.Result == null)                
                //return NotFound();
            //return Ok(ok);
        }
    }
}
