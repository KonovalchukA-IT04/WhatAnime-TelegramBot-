using Telegram.Bot;
using System.Text.Json;
using System.Collections.Generic;
using WhatAnime_TelegramBot_.Models.Bot;
using System.Threading.Tasks;

namespace WhatAnime_TelegramBot_.Commands.Bot
{
    public class LastNews : Command
    {
        public override string Name => "news";
        public override async Task Execute(ResponseInfo.Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.Message_Id;

            var resp = Connections.Find.Response("https://whatanimetelegrambot.azurewebsites.net/api/", "others/news/", "").Result;
            if (resp.StatusCode != System.Net.HttpStatusCode.OK)
            {
                await client.SendTextMessageAsync(chatId, "Wrong enter: nothing found", replyToMessageId: messageId);
                return;
            }
            var result = await resp.Content.ReadAsStringAsync();

            var res_deserl = JsonSerializer.Deserialize<Models.News>(result);
            var new_mes = new List<string>();

            foreach (Models.UsefullNewsData headers in res_deserl.newsList)
            {
                new_mes.Add(headers.title + "\n" + headers.body + "\n" + headers.url_ById);
            }

            await client.SendTextMessageAsync(chatId, new_mes[0], replyToMessageId: messageId);
            await client.SendTextMessageAsync(chatId, new_mes[1], replyToMessageId: messageId);
        }
    }
}
