using Telegram.Bot.Types;
using Telegram.Bot;
using Bot.Panels;

namespace JajaSithTgBot.Implemented.Panels
{
    public class AdminPanel : ControlPanel
    {
        public AdminPanel()
        {
            _Commands = GetDefaultCommands();
        }
        public AdminPanel(IDictionary<string, IControlPanel.CommandDelegateHandler> commands) : this()
        {
            if (commands == null)
                throw new ArgumentNullException(nameof(commands));

            AddCommandRange(commands);
        }

        public override void Process(ITelegramBotClient botClient, Message message, bool IsRequestResultRedirected = false, ChatId? redirectResponseTo = default)
        {
            _Commands.TryGetValue(message?.Text?.Split(' ')[0] ?? string.Empty, out var action);

            action?.Invoke(botClient, message.Chat.Id, IsRequestResultRedirected, IsRequestResultRedirected ? redirectResponseTo ?? throw new NullReferenceException() : redirectResponseTo, requiredData: message?.Text);
        }

        public override async Task ProcessAsync(ITelegramBotClient botClient, Message message, bool IsRequestResultRedirected = false, ChatId? redirectResponseTo = default)
        {
            await Task.Factory.StartNew(() =>
            {
                Process(botClient, message, IsRequestResultRedirected, redirectResponseTo);
            });
        }

        public override IEnumerable<BotCommand> GetBotCommands()
        {
            return _Commands.Keys.Select(xkey => new BotCommand() { Command = xkey.ToLower(), Description = xkey });
        }
    }
}
