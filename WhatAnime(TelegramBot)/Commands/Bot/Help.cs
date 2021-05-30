using System.Threading.Tasks;
using Telegram.Bot;
using WhatAnime_TelegramBot_.Models.Bot;

namespace WhatAnime_TelegramBot_.Commands.Bot
{
    public class Help : Command
    {
        public override string Name => "help";
        public override async Task Execute(ResponseInfo.Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.Message_Id;

            string s = "Information given below, describes the input features and command functionality.\n" +
                "The information in brackets \"[ ]\" after command means using of an additional information, needed for search, and describes the type of necessary information\n" +
                "Command list:\n\n" +
                "/searchanime [word or string] — Search the anime by name\n" +
                "/searchmanga [word or string] — Search the manga by name\n" +
                "/animeid [integer number] — Anime description by id\n" +
                "/mangaid [integer number] — Manga description by id\n\n" +
                "[any one image type \"photo\"] — Search the anime by image (no command required)\n\n" +
                "/quote — Random quote from anime\n" +
                "/news — Two last news from shikimori.one\n\n" +
                "/getlist — Show your anime list\n" +
                "/addtolist [word or string] — Add new anime to your list\n" +
                "/removefromlist [integer number] — Remove an anime from list by number\n" +
                "/offer — Makes offer by your anime list\n";
            await client.SendTextMessageAsync(chatId, s, replyToMessageId: messageId);
        }
    }
}
