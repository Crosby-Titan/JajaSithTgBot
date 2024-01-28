using Telegram.Bot.Types;
using Telegram.Bot;
using System.Diagnostics.CodeAnalysis;
using JajaSithTgBot.Bot.Logging;
using System.ComponentModel.DataAnnotations;

namespace JajaSithTgBot.Bot.Handlers
{
    public class DefaultHandlers : IHandler
    {

        [Required]
        [NotNull]
        public ChatId? ChatId { get; set; }

        [Required]
        [NotNull]
        public ILogger? Logger { get; set; }

        [Required]
        [NotNull]
        public ILogFormatter? LogFormatter { get; set; }

        [Required]
        [NotNull]
        public IResponseHandler? ResponseHandler { get; set; }
        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            switch (update?.Message)
            {
                case not null:
                    await ResponseHandler.HandleAsync(botClient, update.Message);
                    break;
                default:
                    break;
            }
        }

        public async Task HandleErrorAsync(ITelegramBotClient botClient, Exception ex, CancellationToken cancellationToken)
        {
            await Task.Factory.StartNew(() =>
            {
                Logger.Log(LogFormatter.Format(ex));
            }, cancellationToken);
        }
    }
}
