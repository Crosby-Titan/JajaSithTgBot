using Telegram.Bot.Types;

namespace Bot.Types.Factories
{
    public abstract class MediaFactory
    {
        public abstract InputMediaBase CreateMedia(ContentPresenter media);
    }
}
