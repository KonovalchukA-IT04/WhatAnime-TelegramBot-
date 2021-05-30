using Telegram.Bot;
using System.Text.Json;
using System;
using WhatAnime_TelegramBot_.Models.Bot;
using System.Threading.Tasks;

namespace WhatAnime_TelegramBot_.Commands.Bot
{
    public class GetList : Command
    {
        public override string Name => "getlist";
        public override async Task Execute(ResponseInfo.Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.Message_Id;

            var resp = Connections.Find.Response("https://whatanimetelegrambot.azurewebsites.net/api/", "list/get/", Convert.ToString(chatId)).Result;
            if (resp.StatusCode != System.Net.HttpStatusCode.OK)
            {
                await client.SendTextMessageAsync(chatId, "Wrong enter: nothing found", replyToMessageId: messageId);
                return;
            }
            var result = await resp.Content.ReadAsStringAsync();

            Models.AnimeToList list = JsonSerializer.Deserialize<Models.AnimeToList>(result);
            var new_mes = list.name;

            await client.SendTextMessageAsync(chatId, new_mes, replyToMessageId: messageId);
        }
    }
}
