using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatAnime_TelegramBot_.Models;

namespace WhatAnime_TelegramBot_.Repositories
{
    public interface IListRepository
    {
        Task<IEnumerable<AnimeToList>> Get();
        Task<AnimeToList> Get(int id);
        Task<AnimeToList> Create(AnimeToList animeToList);
        Task Delete(int id);
        Task Update(AnimeToList anime);
    }
}
