namespace Bot.Content
{
    public interface IContentDownloader
    {
        public Task<ICollection<ContentPresenter>> LoadContentAsync(string path);
        public ICollection<ContentPresenter> LoadContent(string path);
    }
}
