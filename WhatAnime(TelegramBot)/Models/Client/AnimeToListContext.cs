using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WhatAnime_TelegramBot_.Models
{
    public class AnimeToListContext: DbContext
    {
        public DbSet<AnimeToList> AnimeToLists { get; set; }
        public AnimeToListContext(DbContextOptions<AnimeToListContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
