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
