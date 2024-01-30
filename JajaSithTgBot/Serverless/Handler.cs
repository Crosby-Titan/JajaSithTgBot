using JajaSithTgBot.Implemented.Commands;
using JajaSithTgBot.Implemented.Handlers;
using JajaSithTgBot.Implemented.Logging;
using JajaSithTgBot.Implemented.Panels;
using JajaSithTgBot.Implemented.Patterns.Builders;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace JajaSithTgBot.Serverless
{
    public class Handler
    {
        private Entry _Entry;
        public async Task<string> FunctionHandler(string request)
        {
            Initialize();

            return await _Entry.FunctionHandler(request);
        }

        private void Initialize()
        {
            var settings = BotHelper.LoadSettigs("telegram_info.json");
            ChatId chatID;

            if (settings.Information.ChannelID.Contains('@'))
                chatID = new ChatId(settings.Information.ChannelID);
            else
                chatID = new ChatId(long.Parse(settings.Information.ChannelID));


            _Entry = new Entry(new TelegramBotClient(settings.Information.ApiKey),
                new DefaultHandlers()
                {
                    LogFormatter = new DefaultErrorLogFormatter(),
                    Logger = new DefaultLogger(),
                    ResponseHandler = new ResponseHandlerBuilder()
                     .UseModule(new AdminPanel(Commands.GetAdminCommands()))
                     .UseModule(new UserPanel(Commands.GetUserCommands()))
                     .UseAnother(chatID)
                     .Build()
                });
        }
    }
}
