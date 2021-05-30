using Telegram.Bot;
using System.Text.Json;
using WhatAnime_TelegramBot_.Models.Bot;
using System.Threading.Tasks;

namespace WhatAnime_TelegramBot_.Commands.Bot
{
    public class Quote : Command
    {
        public override string Name => "quote";
        public override async Task Execute(ResponseInfo.Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.Message_Id;

            var resp = Connections.Find.Response("https://whatanimetelegrambot.azurewebsites.net/api/", "others/quote/", "").Result;
            if (resp.StatusCode != System.Net.HttpStatusCode.OK)
            {
                await client.SendTextMessageAsync(chatId, "Wrong enter: nothing found", replyToMessageId: messageId);
                return;
            }
            var result = await resp.Content.ReadAsStringAsync();

            var res_deserl = JsonSerializer.Deserialize<Models.Quotes>(result);
            var new_mes = "";

            new_mes += "Anime: " + res_deserl.anime + "\n" + "Character: " + res_deserl.character + "\n" + "Quote: " + res_deserl.quote;

            await client.SendTextMessageAsync(chatId, new_mes, replyToMessageId: messageId);
        }
    }
}
