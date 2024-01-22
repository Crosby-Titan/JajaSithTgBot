using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;
using JajaSithTgBot.Bot.Handlers;
using Telegram.Bot.Types.ReplyMarkups;

namespace JajaSithTgBot.Bot.Panels
{
    public interface IControlPanel: IResponseHandlerModule
    {
        public delegate void CommandDelegateHandler(ITelegramBotClient botClient, ChatId id, IResponseHandlerModule? module = default);
        public void Process(ITelegramBotClient botClient,Message message, IResponseHandlerModule? module = default,ChatId? redirectResponseTo = default );
        public Task ProcessAsync(ITelegramBotClient botClient, Message message, IResponseHandlerModule? module = default, ChatId? redirectResponseTo = default);
        public ReplyKeyboardMarkup GetKeyboardPanel();
    }
}
