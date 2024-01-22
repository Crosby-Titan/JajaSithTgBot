using JajaSithTgBot.Bot.Handlers;

namespace JajaSithTgBot.Bot.Content
{
    public interface IContentSelector: IResponseHandlerModule
    {
        bool IsContentAvailable(string cathegory, DateTime destinationTime);

        ICollection<ICollection<ContentPresenter>> GetContent(string cathegoryName, DateTime destinationTime);
    }
}
