using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace JajaSithTgBot.Bot.Handlers
{
    public interface IResponseHandler
    {
        public void Handle(ITelegramBotClient botClient, Message message);
        public Task HandleAsync(ITelegramBotClient client, Message message);
    }
}
