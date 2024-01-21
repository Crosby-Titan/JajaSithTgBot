using JajaSithTgBot.Bot.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace JajaSithTgBot.Bot.Types.Factories
{
    public class PhotoMediaFactory : MediaFactory
    {
        public override InputMediaBase CreateMedia(ContentPresenter media)
        {
            return new InputMediaPhoto(new InputMedia(System.IO.File.OpenRead(media.ContentPath), new FileInfo(media.ContentPath).Name));
        }
    }
}
