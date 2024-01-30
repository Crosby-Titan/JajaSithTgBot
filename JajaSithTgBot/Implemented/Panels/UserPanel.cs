using Bot.Panels;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace JajaSithTgBot.Implemented.Panels
{
    public class UserPanel : ControlPanel
    {
        public UserPanel()
        {
            _Commands = GetDefaultCommands();
        }

        public UserPanel(IDictionary<string, IControlPanel.CommandDelegateHandler> commands) : this()
        {
            if (commands == null)
                throw new ArgumentNullException(nameof(commands));

            AddCommandRange(commands);
        }

        public override void Process(ITelegramBotClient botClient, Message message, bool IsRequestResultRedirected = false, ChatId? redirectResponseTo = null)
        {
            _Commands.TryGetValue(message?.Text ?? string.Empty, out var action);

            action?.Invoke(botClient, message.Chat.Id, IsRequestResultRedirected, IsRequestResultRedirected ? redirectResponseTo ?? throw new NullReferenceException() : redirectResponseTo);
        }

        public override async Task ProcessAsync(ITelegramBotClient botClient, Message message, bool IsRequestResultRedirected = false, ChatId? redirectResponseTo = null)
        {
            await Task.Factory.StartNew(() =>
            {
                Process(botClient, message, IsRequestResultRedirected, redirectResponseTo);
            });
        }

        public override IEnumerable<BotCommand> GetBotCommands()
        {
            return _Commands.Keys.Select(xkey => new BotCommand() { Command = xkey, Description = xkey });
        }
    }
}
