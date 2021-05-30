using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;

namespace WhatAnime_TelegramBot_.Models.Bot
{
    public static class Bot
    {
        private static TelegramBotClient client;
        private static List<Command> commandlist;
        public static IReadOnlyList<Command> Commands { get => commandlist.AsReadOnly(); }
        public static async Task<TelegramBotClient> Get()
        {
            if(client != null)
            {
                return client;
            }
            commandlist = new List<Command>();
            commandlist.Add(new Commands.Bot.SearchTheAnime());
            commandlist.Add(new Commands.Bot.SearchTheManga());
            commandlist.Add(new Commands.Bot.AnimeId());
            commandlist.Add(new Commands.Bot.MangaId());
            commandlist.Add(new Commands.Bot.SearchByImg());
            commandlist.Add(new Commands.Bot.LastNews());
            commandlist.Add(new Commands.Bot.Quote());
            commandlist.Add(new Commands.Bot.AddToList());
            commandlist.Add(new Commands.Bot.GetList());
            commandlist.Add(new Commands.Bot.RemoveFromList());
            commandlist.Add(new Commands.Bot.Offer());
            commandlist.Add(new Commands.Bot.Start());
            commandlist.Add(new Commands.Bot.Help());
            //не забути добавити всі команди сюди

            client = new TelegramBotClient(AppSettings.Key);
            var hook = string.Format(AppSettings.Url, "api/message/update");
            await client.SetWebhookAsync(hook);
            return client;
        }
    }
}
