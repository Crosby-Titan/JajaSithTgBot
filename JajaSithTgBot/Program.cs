using Bot.Logging;
using JajaSithTgBot.Implemented.Commands;
using JajaSithTgBot.Implemented.Handlers;
using JajaSithTgBot.Implemented.Logging;
using JajaSithTgBot.Implemented.Panels;
using JajaSithTgBot.Implemented.Patterns.Builders;
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
                ChatId chatID;

                if(settings.Information.ChannelID.Contains('@'))
                    chatID = new ChatId(settings.Information.ChannelID);
                else
                    chatID = new ChatId(long.Parse(settings.Information.ChannelID));

                BotHelper.InitializeBot(settings, new DefaultHandlers()
                {
                    LogFormatter = new DefaultErrorLogFormatter(),
                    Logger = new DefaultLogger(),
                    ResponseHandler = new ResponseHandlerBuilder()
                     .UseModule(new AdminPanel(Commands.GetAdminCommands()))
                     .UseModule(new UserPanel(Commands.GetUserCommands()))
                     .UseAnother(chatID)
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