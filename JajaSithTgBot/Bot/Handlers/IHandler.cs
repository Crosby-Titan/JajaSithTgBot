using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace JajaSithTgBot.Bot.Handlers
{
    public interface IHandler
    {
        public Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToke);
        public Task HandleErrorAsync(ITelegramBotClient botClient, Exception ex, CancellationToken cancellationToken);
    }
}
