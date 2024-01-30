using Bot;
using Bot.Attributes;
using Bot.Handlers;
using JajaSithTgBot.Implemented.Parsing;
using JajaSithTgBot.Paths;
using Telegram.Bot;
using Telegram.Bot.Polling;

namespace JajaSithTgBot
{
    public class BotHelper
    {
        private static TelegramBot? _Bot;
        private static DataLoader _Loader;

        static BotHelper()
        {
            _Loader = new DataLoader();
        }

        public static async Task Start(ReceiverOptions? options = default)
        {
            if (_Bot == null) 
                throw new NullReferenceException();

            await _Bot.StartReceiveAsync(options);
        }

        public static void Stop()
        {
            _Bot?.Dispose();
        }

        public static void InitializeBot(TelegramSettings? settings, IHandler handler)
        {
            if (settings == null)
                throw new NullReferenceException();                

            if (!SettingsValidator.Validate<TelegramSettings, SettingsValidationAttribute>(settings))
                throw new ArgumentException(null, nameof(settings));

            _Bot = new TelegramBot(new TelegramBotClient(settings.Information.ApiKey),handler, settings.Information.ChannelID);
        }

        public static TelegramSettings? LoadSettigs(string filename)
        {
            return _Loader.Load<TelegramSettings>(File.OpenRead(Path.Combine(PathWorker.Telegram, filename)));
        }
    }
}
