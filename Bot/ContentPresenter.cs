using Telegram.Bot.Types.Enums;

namespace Bot
{
    public class ContentPresenter
    {
        private string _ContentPath;
        private string _Tag;
        private InputMediaType _MediaType;
        private DirectoryInfo? _Directory;

        public ContentPresenter(string path, string tag)
        {
            if (string.IsNullOrEmpty(path) || string.IsNullOrEmpty(tag))
                throw new ArgumentNullException(null, $"{nameof(path)} or {nameof(tag)} was empty.");

            _ContentPath = path;
            _Tag = tag;
            _MediaType = GetType(tag);
            _Directory = new FileInfo(path)?.Directory;
        }

        public string ContentPath { get { return _ContentPath; } }
        public string Tag { get { return _Tag; } }
        public InputMediaType MediaType { get { return _MediaType; } }
        public DirectoryInfo? DirectoryInfo
        {
            get
            {
                if (_Directory == null)
                    return null;

                return new DirectoryInfo(_Directory.FullName);
            }
        }

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
