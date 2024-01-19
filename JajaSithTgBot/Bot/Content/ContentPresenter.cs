using Telegram.Bot.Types.Enums;

namespace JajaSithTgBot.Bot.Content
{
    public class ContentPresenter
    {
        private string _ContentPath;
        private string _Tag;
        private InputMediaType _MediaType;

        public ContentPresenter(string path, string tag)
        {
            if (string.IsNullOrEmpty(path) || string.IsNullOrEmpty(tag))
                throw new ArgumentNullException(null, $"{nameof(path)} or {nameof(tag)} was empty.");

            _ContentPath = path;
            _Tag = tag;
            _MediaType = GetType(tag);
        }

        public string ContentPath { get { return _ContentPath; } }
        public string Tag { get { return _Tag; } }
        public InputMediaType MediaType { get { return _MediaType; } }

        public static InputMediaType GetType(string tag)
        {
            switch (tag)
            {
                case "#арт":
                    return InputMediaType.Photo;
                case "#видео":
                    return InputMediaType.Video;
                default:
                    throw new ArgumentException(null, nameof(tag));
            }
        }

    }
}
