using Telegram.Bot;
using Telegram.Bot.Types;

namespace JajaSithTgBot.Bot.Handlers
{
    public interface IPostHandler: IResponseHandlerModule
    {
        public delegate Task<Message[]> SendMediaGroupAsync(ChatId id, IEnumerable<IAlbumInputMedia> media, int? threadid = null, bool? disablenotify = null, bool? protectContent = null, int? replyToMessageId = null, bool? allowSendingWithoutReply = null, CancellationToken token = default);
        public Task PostAsync(SendMediaGroupAsync sendFunc, IDictionary<string, IEnumerable<IAlbumInputMedia>> data, ChatId chat);
        public Task PostAsync(ITelegramBotClient botClient, IDictionary<string, IEnumerable<IAlbumInputMedia>> data, ChatId chat);

    }
}
