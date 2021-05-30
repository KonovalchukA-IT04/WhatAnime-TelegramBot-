using Telegram.Bot;
using System.Text.Json;
using WhatAnime_TelegramBot_.Models.Bot;
using System.Threading.Tasks;

namespace WhatAnime_TelegramBot_.Commands.Bot
{
    public class MangaId : Command
    {
        public override string Name => "mangaid";
        public override async Task Execute(ResponseInfo.Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.Message_Id;
            var messageText = message.Text;

            messageText = Help_tools.Help_meth.CommandRemover(messageText, Name);

            var resp = Connections.Find.Response("https://whatanimetelegrambot.azurewebsites.net/api/", "manga/id/", messageText).Result;
            if (resp.StatusCode != System.Net.HttpStatusCode.OK)
            {
                await client.SendTextMessageAsync(chatId, "Wrong enter: nothing found", replyToMessageId: messageId);
                return;
            }
            var result = await resp.Content.ReadAsStringAsync();

            var res_deserl = JsonSerializer.Deserialize<Models.UsefulAnimeData>(result);
            var new_mes = "";

            new_mes += "Id: " + res_deserl.id + "\n" + "Title: " + res_deserl.title + "\n" + "Title_en: " + res_deserl.title_en + "\n" +
                "URL: " + res_deserl.url + "\n" + "Genres: " + res_deserl.genres + "\n" + "Episodes: " + res_deserl.episodes + "\n" +
                "Premiered: " + res_deserl.premiered + "\n" + "Score: " + res_deserl.score + "\n" + "Synopsis: " + res_deserl.synopsis;

            await client.SendPhotoAsync(chatId, res_deserl.img_url);
            await client.SendTextMessageAsync(chatId, new_mes, replyToMessageId: messageId);
        }
    }
}
