using Telegram.Bot.Types;
using Telegram.Bot;
using Bot.Handlers;

namespace Bot.Panels
{
    public interface IControlPanel: IResponseHandlerModule
    {
        public delegate void CommandDelegateHandler(ITelegramBotClient botClient, ChatId id, bool IsRequestResultRedirected = false, ChatId? redirectResultTo = default,object? requiredData = default);
        public void Process(ITelegramBotClient botClient,Message message, bool IsRequestResultRedirected = false, ChatId? redirectResultTo = default);
        public Task ProcessAsync(ITelegramBotClient botClient, Message message, bool IsRequestResultRedirected = false, ChatId? redirectResultTo = default);    }
}
