namespace JajaSithTgBot.Bot.Content
{
    public interface IContentSelector
    {
        bool IsContentAvailable(string cathegory, DateTime destinationTime);

        ICollection<ICollection<ContentPresenter>> GetContent(string cathegoryName, DateTime destinationTime);
    }
}
