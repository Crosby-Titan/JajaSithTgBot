using JajaSithTgBot.Bot.JSON;
using JajaSithTgBot.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot;
using JajaSithTgBot.Bot.Handlers;
using JajaSithTgBot.Bot.Paths;
using JajaSithTgBot.Bot.Attributes;

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

        public static async Task Start(TelegramSettings? settings, ReceiverOptions? options = default)
        {
            InitializeBot(settings ?? throw new NullReferenceException(nameof(settings)));

            await _Bot.StartReceiveAsync();
        }

        public static void Stop()
        {
            _Bot?.Dispose();
        }

        private static void InitializeBot(TelegramSettings settings,IHandler? handler = default)
        {
            if(!SettingsValidator.Validate<TelegramSettings,SettingsValidationAttribute>(settings))
                throw new ArgumentException(null, nameof(settings));

            _Bot = new TelegramBot(new TelegramBotClient(settings.Information.ApiKey), settings.Information.ChannelID)
            {
                Handler = handler
            };
        }

        public static TelegramSettings? LoadSettigs()
        {
            return _Loader.Load<TelegramSettings>(File.OpenRead(Path.Combine(PathWorker.Telegram, "telegram_info.json")));
        }
    }
}
