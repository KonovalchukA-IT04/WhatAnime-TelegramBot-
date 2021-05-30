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
    public class ListController : ControllerBase
    {
        private readonly Repositories.IListRepository _listRepository;
        public ListController(Repositories.IListRepository listRepository)
        {
            _listRepository = listRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Models.AnimeToList>> Get()
        {
            return await _listRepository.Get();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.AnimeToList>> Get(int id)
        {
            return await _listRepository.Get(id);
        }
        [HttpPost]
        public async Task<ActionResult<Models.AnimeToList>> Post([FromBody] Models.AnimeToList anime)
        {
            var newAnime = await _listRepository.Create(anime);
            return CreatedAtAction(nameof(Get), new { id = newAnime.id }, newAnime);
        }
        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] Models.AnimeToList anime)
        {
            if (id!=anime.id)
            {
                return BadRequest();
            }
            await _listRepository.Update(anime);
            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult> AddList(int id, string input)
        {
            var animelisttoupdate = await _listRepository.Get(id);
            if (animelisttoupdate == null)
            {
                await Post(new Models.AnimeToList { name = input, id = id });
                //var newAnime = await _listRepository.Create(new Models.AnimeToList { Name = input, Id = id});
                //return CreatedAtAction(nameof(Get), new { id = newAnime.Id }, newAnime);
                return NoContent();
            }
            animelisttoupdate.name = animelisttoupdate.name + "\n" + input;
            await _listRepository.Update(animelisttoupdate);
            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult> RemoveNum(int id, int num)
        {
            var animelisttoupdate = await _listRepository.Get(id);
            if (animelisttoupdate == null)
                return NotFound();
            string s = Help_tools.Help_meth.Parser(animelisttoupdate.name, num);
            if (String.IsNullOrEmpty(s))
                await _listRepository.Delete(animelisttoupdate.id);
            animelisttoupdate.name = s;
            await _listRepository.Update(animelisttoupdate);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var animetodelete = await _listRepository.Get(id);
            if (animetodelete == null)
                return NotFound();
            await _listRepository.Delete(animetodelete.id);
            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<Models.ShortData> Offer(int id)
        {
            var animetodelete = await _listRepository.Get(id);
            if (animetodelete == null)
                return null;
            var titles = await _listRepository.Get(id);
            return Commands.Client.Offer.Make(titles).Result;
        }
    }
}
