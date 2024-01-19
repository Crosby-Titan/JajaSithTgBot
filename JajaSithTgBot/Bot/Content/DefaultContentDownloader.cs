namespace JajaSithTgBot.Bot.Content
{
    public class DefaultContentDownloader : IContentDownloader
    {
        public ICollection<ContentPresenter> LoadContent(string path)
        {
            if (!Directory.Exists(path))
                throw new ArgumentException(null, nameof(path));

            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            FileInfo[]? files = directoryInfo.GetFiles();

            ICollection<ContentPresenter> content = new List<ContentPresenter>(files.Length);

            var result = Parallel.ForEach(files, file =>
            {
                content.Add(new ContentPresenter(file.FullName,
                    $"#{directoryInfo?.Parent?.Name ?? directoryInfo.Name}"));
            });

            return result.IsCompleted ? content : Array.Empty<ContentPresenter>();
        }

        public async Task<ICollection<ContentPresenter>> LoadContentAsync(string path)
        {
            return await Task.Factory.StartNew(() => LoadContent(path));
        }
    }
}
