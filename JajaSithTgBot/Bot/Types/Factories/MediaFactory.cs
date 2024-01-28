using JajaSithTgBot.Bot.Content;
using Telegram.Bot.Types;

namespace JajaSithTgBot.Bot.Types.Factories
{
    public abstract class MediaFactory
    {
        public abstract InputMediaBase CreateMedia(ContentPresenter media);
    }
}
