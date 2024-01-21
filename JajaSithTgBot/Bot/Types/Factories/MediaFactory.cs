using JajaSithTgBot.Bot.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace JajaSithTgBot.Bot.Types.Factories
{
    public abstract class MediaFactory
    {
        public abstract InputMediaBase CreateMedia(ContentPresenter media);
    }
}
