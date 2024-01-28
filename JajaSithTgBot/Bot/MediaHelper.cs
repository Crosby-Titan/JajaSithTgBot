using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using JajaSithTgBot.Bot.Content;
using JajaSithTgBot.Bot.Extensions;

namespace JajaSithTgBot.Bot
{
    public class MediaHelper
    {
        private static readonly MediaHelper _Helper = new MediaHelper();
        public static IEnumerable<InputMediaBase> GetMedia(ICollection<ContentPresenter> media)
        {
            List<InputMediaBase> mediaList = new List<InputMediaBase>(media.Count);

            Parallel.ForEach(media, item =>
            {
                mediaList.Add(_Helper.CreateMedia(item) ?? throw new NullReferenceException());
            });

            return mediaList;
        }

        public static IDictionary<string, IEnumerable<IAlbumInputMedia>> GetSortedMedia(ICollection<ContentPresenter> media)
        {
            var mediaTable = new Dictionary<string, IEnumerable<IAlbumInputMedia>>();

            foreach (var item in media)
            {
                if (!mediaTable.ContainsKey(item.Tag))
                {
                    mediaTable.Add(item.Tag, new List<IAlbumInputMedia>());
                }

                ((List<IAlbumInputMedia>)mediaTable[item.Tag]).Add((IAlbumInputMedia?)_Helper.CreateMedia(item) ?? throw new NullReferenceException());
            }

            return mediaTable;
        }
        [Obsolete($"Use {nameof(MediaHelperExtension.CreateMedia)} instead")]
        public static InputMediaBase GetSpecifiedMedia(ContentPresenter media)
        {
            switch (media.MediaType)
            {
                case InputMediaType.Photo:
                    return new InputMediaPhoto(new InputMedia(System.IO.File.OpenRead(media.ContentPath), new FileInfo(media.ContentPath).Name));
                case InputMediaType.Video:
                    return new InputMediaVideo(new InputMedia(System.IO.File.OpenRead(media.ContentPath), new FileInfo(media.ContentPath).Name));
                default:
                    throw new ArgumentException(null, nameof(media));
            }
        }

        public static IEnumerable<IAlbumInputMedia> ConvertTo(IEnumerable<InputMedia> medias)
        {
            return medias.Select(x => (IAlbumInputMedia)x);
        }

    }

}
