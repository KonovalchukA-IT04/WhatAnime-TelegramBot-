using System.Collections.Generic;
using Telegram.Bot;
using System.Text.Json;
using WhatAnime_TelegramBot_.Models.Bot;
using System.Threading.Tasks;

namespace WhatAnime_TelegramBot_.Commands.Bot
{
    public class SearchByImg : Command
    {
        public override string Name => "searchimg";
        public override async Task Execute(ResponseInfo.Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.Message_Id;
            if (message.Photo == null)
            {
                await client.SendTextMessageAsync(chatId, "Wrong enter: nothing found", replyToMessageId: messageId);
                return;
            }
            var fileId = message.Photo[0].File_Id;

            var getpath = Connections.Find.Response("https://api.telegram.org/bot1747914945:AAHuqDUBywyIrC5s0BwI7p8Wm3FUVcoM8ds/", "getFile?file_id=", fileId).Result;
            var imginf = await getpath.Content.ReadAsStringAsync();
            var shortmodel = JsonSerializer.Deserialize<Models.Bot.ImgInfo.Root>(imginf);

            var url = "https://api.telegram.org/file/bot1747914945:AAHuqDUBywyIrC5s0BwI7p8Wm3FUVcoM8ds/" + shortmodel.result.file_path;
            var resp = Connections.Find.Response("https://whatanimetelegrambot.azurewebsites.net/api/", "anime/img?url=", url).Result;
            if (resp.StatusCode != System.Net.HttpStatusCode.OK)
            {
                await client.SendTextMessageAsync(chatId, "Wrong enter: nothing found", replyToMessageId: messageId);
                return;
            }
            var result = await resp.Content.ReadAsStringAsync();

            var res_deserl = JsonSerializer.Deserialize<Models.UsefullImgData>(result);

            var new_list = new List<Models.ImgData>();
            for (int i = 0; i < 5; i++)
            {
                new_list.Add(res_deserl.imgDataList[i]);
            }

            var new_mes = "";

            foreach (Models.ImgData headers in new_list)
            {
                new_mes += "Id: " + headers.id + "\n" + "Title: " + headers.title + "\n" + "TitleEn: " + headers.title_en + "\n\n";
            }

            await client.SendTextMessageAsync(chatId, new_mes, replyToMessageId: messageId);
        }
    }
}
