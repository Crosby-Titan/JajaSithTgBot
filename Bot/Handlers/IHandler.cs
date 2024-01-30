using Telegram.Bot.Types;
using Telegram.Bot;

namespace Bot.Handlers
{
    public interface IHandler
    {
        public Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToke);
        public Task HandleErrorAsync(ITelegramBotClient botClient, Exception ex, CancellationToken cancellationToken);
    }
}
