using System.Threading.Tasks;
using Telegram.Bot;
using WhatAnime_TelegramBot_.Models.Bot;

namespace WhatAnime_TelegramBot_.Commands.Bot
{
    public class Start : Command
    {
        public override string Name => "start";
        public override async Task Execute(ResponseInfo.Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.Message_Id;

            string s = "Hello, dear user! To learn the functionality, write /help.\nPlease, bear in mind, that necessary information for commands entering after the command name separated by space. Read more in /help.";
            await client.SendTextMessageAsync(chatId, s, replyToMessageId: messageId);
        }
    }
}
