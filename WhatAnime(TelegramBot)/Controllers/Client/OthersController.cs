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
    public class OthersController : ControllerBase
    {
        [HttpGet]
        public Models.Quotes Quote()
        {
            return Commands.Client.Others.SearchQuote().Result;
            //var ok = Commands.Client.Others.SearchQuote();
            //if (ok.Result == null)
            //    return NotFound();
            //return Ok(ok);
        }
        [HttpGet]
        public Models.News News()
        {
            return Commands.Client.Others.SearchNews().Result;
            //var ok = Commands.Client.Others.SearchNews();
            //if (ok.Result == null)
            //    return NotFound();
            //return Ok(ok);
        }
    }
}
