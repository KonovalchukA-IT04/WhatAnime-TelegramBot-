using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WhatAnime_TelegramBot_.Models.Bot;

namespace WhatAnime_TelegramBot_.Controllers.Bot
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        [HttpPost]
        public async Task<OkResult> Update(ResponseInfo.Result update)
        {
            if (update == null) return Ok();

            var commands = Models.Bot.Bot.Commands;
            var message = update.Message;
            var client = await Models.Bot.Bot.Get();

            if (message.Text == null)
            {
                if(message.Photo != null)
                {
                    message.Text = "searchimg";
                }
                else
                {
                    return Ok();
                }
            }

            foreach (var command in commands)
            {
                if (command.Contains(message.Text))
                {
                    await command.Execute(message, client);
                    break;
                }
            }
            return Ok();
        }
    }
}
