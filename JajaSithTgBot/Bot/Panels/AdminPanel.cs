using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using JajaSithTgBot.Bot.Handlers;
using JajaSithTgBot.Bot.Panels.UserTypes;
using System.Dynamic;
using System.Text.Json;

namespace JajaSithTgBot.Bot.Panels
{
    public class AdminPanel : ControlPanel
    {
        public AdminPanel(IDictionary<string, IControlPanel.CommandDelegateHandler> commands)
        {
            _Commands = commands ?? throw new ArgumentNullException(nameof(commands));
        }

        public override void Process(ITelegramBotClient botClient, Message message, IResponseHandlerModule? module = default, ChatId? redirectResponseTo = default)
        {
            _Commands.TryGetValue(message?.Text ?? string.Empty, out var action);

            action?.Invoke(botClient,redirectResponseTo ?? message.Chat.Id, module);
        }

        public override async Task ProcessAsync(ITelegramBotClient botClient, Message message, IResponseHandlerModule? module = default, ChatId? redirectResponseTo = default)
        {
            await Task.Factory.StartNew(() =>
            {
                Process(botClient, message, module, redirectResponseTo);
            });
        }

        public override ReplyKeyboardMarkup GetKeyboardPanel()
        {
            return new ReplyKeyboardMarkup(new[]
            {
                new KeyboardButton[] { new KeyboardButton("Check media") },
                new KeyboardButton[] { new KeyboardButton("Post media") }
            });
        }
    }
}
