using Bot.Handlers;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace JajaSithTgBot.LocalMachine
{
    public class TelegramBot : IDisposable
    {
        private readonly ITelegramBotClient _Client;
        private readonly ChatId _ChatID;
        private readonly CancellationTokenSource _CancelToken;
        private readonly IHandler _Handler;

        public TelegramBot(ITelegramBotClient botClient, IHandler Handler, string pinnedChannel)
        {
            _Client = botClient ?? throw new ArgumentNullException(nameof(botClient));
            _Handler = Handler ?? throw new ArgumentNullException(nameof(Handler));
            _ChatID = pinnedChannel ?? throw new ArgumentNullException(nameof(pinnedChannel));
            _CancelToken = new CancellationTokenSource();
        }

        internal ITelegramBotClient Client { get { return _Client; } }

        internal CancellationToken CancellationToken { get { return _CancelToken.Token; } }

        public ChatId ChatId { get { return new ChatId(_ChatID.Username ?? throw new ArgumentException()); } }

        public IHandler Handler { get { return _Handler; } }

        public async Task StartReceiveAsync(ReceiverOptions? options = default)
        {
            if (_Client == null || Handler == null)
                throw new NullReferenceException();

            await Task.Run(() =>
            {
                _Client.StartReceiving(
                    Handler.HandleUpdateAsync,
                    Handler.HandleErrorAsync,
                    cancellationToken: _CancelToken.Token,
                    receiverOptions: options);
            });
        }

        public void Dispose()
        {
            _Client.CloseAsync(_CancelToken.Token).Wait();
        }
    }
}
