using Bot;
using Bot.Content;
using JajaSithTgBot.Extensions;
using JajaSithTgBot.Paths;
using Microsoft.VisualBasic.FileIO;

namespace JajaSithTgBot.Implemented
{
    public class DefaultContentSelector : IContentSelector
    {
        private IContentDownloader _Downloader;
        private bool _IsContentAvailable = false;

        public DefaultContentSelector()
        {
            _Downloader = new DefaultContentDownloader();
        }

        public ICollection<ICollection<ContentPresenter>> GetContent(string cathegoryName, DateTime destinationTime)
        {
            if (!_IsContentAvailable)
                return Array.Empty<ICollection<ContentPresenter>>();

            DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(PathWorker.Content, cathegoryName));
            var content = new List<ICollection<ContentPresenter>>();

            foreach (DirectoryInfo dir in directoryInfo.GetDirectories())
            {
                if (dir.Name == destinationTime.ToShortDateString('-'))
                {
                    content.Add(_Downloader.LoadContent(dir.FullName));
                }

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

            if (!info.Exists)
                return _IsContentAvailable;

            foreach (DirectoryInfo dir in info.GetDirectories())
            {
                if (dir.Name == destinationTime.ToShortDateString('-'))
                    _IsContentAvailable = true;
            }

            return _IsContentAvailable;
        }
    }
}
