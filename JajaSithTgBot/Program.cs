using JajaSithTgBot.Bot;
using JajaSithTgBot.Bot.Handlers;
using JajaSithTgBot.Bot.Logging;
using JajaSithTgBot.Bot.Panels;
using JajaSithTgBot.Bot.Types.Builders;
using Telegram.Bot.Types;

namespace JajaSithTgBot
{
    internal class Program
    {
        private static readonly ILogger Logger = new DefaultLogger(); 
        private static readonly ILogFormatter LogFormatter = new DefaultErrorLogFormatter();
        static async Task Main(string[] args)
        {
            try
            {
                var settings = BotHelper.LoadSettigs("telegram_info.json");

                BotHelper.InitializeBot(settings, new DefaultHandlers()
                {
                    LogFormatter = new DefaultErrorLogFormatter(),
                    Logger = new DefaultLogger(),
                    ResponseHandler = new ResponseHandlerBuilder()
                     .UseModule(new AdminPanel(Commands.GetAdminCommands()))
                     .UseModule(new UserPanel(Commands.GetUserCommands()))
                     .UseAnother(new ChatId(settings.Information.ChannelID))
                     .Build()
                });
                await BotHelper.Start(new Telegram.Bot.Polling.ReceiverOptions() { AllowedUpdates = new Telegram.Bot.Types.Enums.UpdateType[]{ Telegram.Bot.Types.Enums.UpdateType.Message }});

                Console.ReadLine();

                BotHelper.Stop();

            }
            catch (Exception ex)
            {
                Logger.Log(LogFormatter.Format(ex));
            }
        }
    }
}