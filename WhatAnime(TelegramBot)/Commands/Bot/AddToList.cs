using Telegram.Bot;
using System.Net.Http;
using WhatAnime_TelegramBot_.Models.Bot;
using System.Threading.Tasks;

namespace WhatAnime_TelegramBot_.Commands.Bot
{
    public class AddToList : Command
    {
        public override string Name => "addtolist";
        public override async Task Execute(ResponseInfo.Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.Message_Id;
            var messageText = message.Text;

            messageText = Help_tools.Help_meth.CommandRemover(messageText, Name);
            if (string.IsNullOrWhiteSpace(messageText))
            {
                await client.SendTextMessageAsync(chatId, "NoContentAdded", replyToMessageId: messageId);
                return;
            }

            var clt = new HttpClient();
            string s = $"https://whatanimetelegrambot.azurewebsites.net/api/list/addlist/?id={chatId}&input={messageText}";
            var resp = await clt.PutAsync(s, null);

            await client.SendTextMessageAsync(chatId, "Done", replyToMessageId: messageId);
        }
    }
}
