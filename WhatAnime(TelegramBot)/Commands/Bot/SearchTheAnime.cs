using Telegram.Bot;
using System.Text.Json;
using WhatAnime_TelegramBot_.Models.Bot;
using System.Threading.Tasks;

namespace WhatAnime_TelegramBot_.Commands.Bot
{
    public class SearchTheAnime : Command
    {
        public override string Name => "searchanime";
        public override async Task Execute(ResponseInfo.Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.Message_Id;
            var messageText = message.Text;

            messageText = Help_tools.Help_meth.CommandRemover(messageText, Name);

            var resp = Connections.Find.Response("https://whatanimetelegrambot.azurewebsites.net/api/", "anime/name/", messageText).Result;
            if (resp.StatusCode != System.Net.HttpStatusCode.OK)
            {
                await client.SendTextMessageAsync(chatId, "Wrong enter: nothing found", replyToMessageId: messageId);
                return;
            }
            var result = await resp.Content.ReadAsStringAsync();

            var res_deserl = JsonSerializer.Deserialize<Models.UsefullResult>(result);
            var new_mes = "";

            foreach (Models.ShortData headers in res_deserl.dataList)
            {
                new_mes += "Id: " + headers.id + "\n" + "Title: " + headers.title + "\n" + "URL: " + headers.url + "\n\n";
            }

            await client.SendTextMessageAsync(chatId, new_mes, replyToMessageId: messageId);
        }
    }
}
