using JajaSithTgBot.Bot.Handlers;
using JajaSithTgBot.Bot.Panels.UserTypes;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace JajaSithTgBot.Bot.Panels
{
    public abstract class ControlPanel : IControlPanel
    {
        public abstract ReplyKeyboardMarkup GetKeyboardPanel();
        public abstract void Process(ITelegramBotClient botClient, Message message, IResponseHandlerModule? module = null, ChatId? redirectResponseTo = null);
        public abstract Task ProcessAsync(ITelegramBotClient botClient, Message message, IResponseHandlerModule? module = null, ChatId? redirectResponseTo = null);

    }
}
