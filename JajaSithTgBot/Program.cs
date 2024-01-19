using JajaSithTgBot.Bot;
using JajaSithTgBot.Bot.JSON;
using JajaSithTgBot.Bot.Paths;
using Telegram.Bot;
using Telegram.Bot.Polling;

namespace JajaSithTgBot
{
    internal class Program
    {
        private static TelegramBot? _Bot;
        private static DataLoader _Loader = new DataLoader();
        static async Task Main(string[] args)
        {
            await Start(_Loader.Load<Service>(File.OpenRead(Path.Combine(PathWorker.Telegram, "telegram_info.json"))));

            Console.ReadLine();
        }

        public static async Task Start(Service? info,ReceiverOptions? options = default)
        {
            await Task.Factory.StartNew(async () =>
            {
                InitializeBot(info ?? throw new NullReferenceException(nameof(info)));

                await _Bot.StartReceiveAsync();
            });
        }

        private static void InitializeBot(Service service)
        {
            _Bot = new TelegramBot(new TelegramBotClient(service.Information.ApiKey), service.Information.ChannelID);
        }
    }
}