using System.Threading.Tasks;
using Telegram.Bot;

namespace WhatAnime_TelegramBot_.Models.Bot
{
    public abstract class Command
    {
        public abstract string Name { get;}
        public abstract Task Execute(ResponseInfo.Message message, TelegramBotClient client);
        public bool Contains(string command)
        {
            return command.Contains(this.Name);
        }
    }
}
