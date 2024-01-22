using JajaSithTgBot.Bot.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace JajaSithTgBot.Bot.Panels
{
    public class UserPanel : ControlPanel
    {
        private IDictionary<string, IControlPanel.CommandDelegateHandler> _Commands;

        public UserPanel(IDictionary<string, IControlPanel.CommandDelegateHandler> commands)
        {
            _Commands = commands ?? throw new ArgumentNullException(nameof(commands));
        }

        public override ReplyKeyboardMarkup GetKeyboardPanel()
        {
            throw new NotImplementedException();
        }

        public override void Process(ITelegramBotClient botClient, Message message, IResponseHandlerModule? module = default, ChatId? redirectResponseTo = null)
        {
            _Commands.TryGetValue(message?.Text ?? string.Empty, out var action);

            action?.Invoke(botClient, redirectResponseTo ?? message.Chat.Id, module);
        }

        public override async Task ProcessAsync(ITelegramBotClient botClient, Message message, IResponseHandlerModule? module = default, ChatId? redirectResponseTo = null)
        {
            await Task.Factory.StartNew(() =>
            {
                Process(botClient, message, module ,redirectResponseTo);
            });
        }
    }
}
