using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatAnime_TelegramBot_.Models;

namespace WhatAnime_TelegramBot_.Repositories
{
    public class ListRepository : IListRepository
    {
        private readonly Models.AnimeToListContext _context;

        public ListRepository(AnimeToListContext context)
        {
            _context = context;
        }

        public async Task<AnimeToList> Create(AnimeToList animeToList)
        {
            _context.AnimeToLists.Add(animeToList);
            await _context.SaveChangesAsync();

            return animeToList;
        }

        public async Task Delete(int id)
        {
            var animetodelete = await _context.AnimeToLists.FindAsync(id);
            _context.AnimeToLists.Remove(animetodelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AnimeToList>> Get()
        {
            return await _context.AnimeToLists.ToListAsync();
        }

        public async Task<AnimeToList> Get(int id)
        {
            return await _context.AnimeToLists.FindAsync(id);
        }
        public async Task Update(Models.AnimeToList anime)
        {
            _context.Entry(anime).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
