using JajaSithTgBot.Bot.Handlers;
using JajaSithTgBot.Bot.Content;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using JajaSithTgBot.Bot.Logging;
using JajaSithTgBot.Bot.Types.Builders;

namespace JajaSithTgBot.Bot
{
    public class TelegramBot : IDisposable
    {
        private readonly ITelegramBotClient _Client;
        private readonly ChatId _ChatID;
        private readonly CancellationTokenSource _CancelToken;
        private IHandler? _Handler;

        public TelegramBot(ITelegramBotClient botClient, string pinnedChannel)
        {
            _Client = botClient ?? throw new ArgumentNullException(nameof(botClient));
            _ChatID = pinnedChannel ?? throw new ArgumentNullException(nameof(pinnedChannel));
            _CancelToken = new CancellationTokenSource();
        }

        public ChatId ChatId { get { return new ChatId(_ChatID.Username ?? throw new ArgumentException()); } }

        public IHandler? Handler
        {
            get
            {
                if (_Handler == null)
                {
                    _Handler = new DefaultHandlers()
                    {
                        ChatId = ChatId,
                        LogFormatter = new DefaultErrorLogFormatter(),
                        Logger = new DefaultLogger(),
                        ResponseHandler = new ResponseHandlerBuilder()
                        .UseAnother(_ChatID)
                        .Build()
                    };

                    return _Handler;
                }

                return _Handler;
            }
            set => _Handler = value;
        }

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
