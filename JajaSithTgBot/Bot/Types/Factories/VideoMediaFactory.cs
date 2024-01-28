using JajaSithTgBot.Bot.Content;
using Telegram.Bot.Types;

namespace JajaSithTgBot.Bot.Types.Factories
{
    public class VideoMediaFactory : MediaFactory
    {
        public override InputMediaBase CreateMedia(ContentPresenter media)
        {
            return new InputMediaVideo(new InputMedia(System.IO.File.OpenRead(media.ContentPath), new FileInfo(media.ContentPath).Name));
        }
    }
}
