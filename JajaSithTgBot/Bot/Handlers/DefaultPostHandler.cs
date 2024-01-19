using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using static JajaSithTgBot.Bot.Handlers.IPostHandler;

namespace JajaSithTgBot.Bot.Handlers
{
    public class DefaultPostHandler : IPostHandler
    {
        public async Task PostAsync(SendMediaGroupAsync sendFunc, IDictionary<string, IEnumerable<IAlbumInputMedia>> data, ChatId chat)
        {

            await Task.Factory.StartNew(() =>
            {

                foreach (var album in data)
                {
                    ((InputMediaBase)album.Value.ElementAt(0)).Caption = album.Key;

                    sendFunc.Invoke(chat, album.Value);
                }

            });
        }

        public async Task PostAsync(ITelegramBotClient botClient, IDictionary<string, IEnumerable<IAlbumInputMedia>> data, ChatId chat)
        {
            await Task.Factory.StartNew(() =>
            {
                foreach (var album in data)
                {
                    ((InputMediaBase)album.Value.ElementAt(0)).Caption = album.Key;

                    botClient.SendMediaGroupAsync(chat, album.Value);
                }

            });
        }


    }
}
