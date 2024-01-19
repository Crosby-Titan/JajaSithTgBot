using JajaSithTgBot.Bot.Extensions;
using JajaSithTgBot.Bot.Paths;

namespace JajaSithTgBot.Bot.Content
{
    public class DefaultContentSelector : IContentSelector
    {
        private IContentDownloader _Downloader;

        public DefaultContentSelector()
        {
            _Downloader = new DefaultContentDownloader();
        }

        public ICollection<ICollection<ContentPresenter>> GetContent(string cathegoryName, DateTime destinationTime)
        {
            if (!IsContentAvailable(cathegoryName, destinationTime))
                return Array.Empty<ICollection<ContentPresenter>>();

            DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(PathWorker.Content, cathegoryName));
            var content = new List<ICollection<ContentPresenter>>();

            foreach (DirectoryInfo dir in directoryInfo.GetDirectories())
            {
                if (dir.Name == destinationTime.ToShortDateString('-'))
                    content.Add(_Downloader.LoadContent(dir.FullName));
            }

            return content;
        }

        public bool IsContentAvailable(string cathegory, DateTime destinationTime)
        {
            DirectoryInfo info = new DirectoryInfo(Path.Combine(PathWorker.Content, cathegory));

            return IsUploadedContentAvailable(info, destinationTime);
        }

        private bool IsUploadedContentAvailable(DirectoryInfo info, DateTime destinationTime)
        {
            bool isContentAvailable = false;

            foreach (DirectoryInfo dir in info.GetDirectories())
            {
                if (dir.Name == destinationTime.ToShortDateString('-'))
                    isContentAvailable = true;
            }

            return isContentAvailable;
        }
    }
}
