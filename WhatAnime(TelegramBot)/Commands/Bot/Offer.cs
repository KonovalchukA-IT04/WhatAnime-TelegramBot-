using Telegram.Bot;
using WhatAnime_TelegramBot_.Models.Bot;
using System.Threading.Tasks;
using System.Text.Json;
using System;

namespace WhatAnime_TelegramBot_.Commands.Bot
{
    public class Offer : Command
    {
        public override string Name => "offer";
        public override async Task Execute(ResponseInfo.Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.Message_Id;

            var resp = Connections.Find.Response("https://whatanimetelegrambot.azurewebsites.net/api/", "list/offer/", Convert.ToString(chatId)).Result;
            if (resp.StatusCode != System.Net.HttpStatusCode.OK)
            {
                await client.SendTextMessageAsync(chatId, "Wrong enter: nothing found", replyToMessageId: messageId);
                return;
            }
            var result = await resp.Content.ReadAsStringAsync();

            var list = JsonSerializer.Deserialize<Models.ShortData>(result);
            var new_mes = "Id: " + list.id + "\n" + "Title: " + list.title + "\n" + "URL: " + list.url;

            await client.SendTextMessageAsync(chatId, new_mes, replyToMessageId: messageId);
        }
    }
}
