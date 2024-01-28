﻿using JajaSithTgBot.Bot.Content;
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
