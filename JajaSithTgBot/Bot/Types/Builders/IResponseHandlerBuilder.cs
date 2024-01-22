using JajaSithTgBot.Bot.Handlers;

namespace JajaSithTgBot.Bot.Types.Builders
{
    public interface IResponseHandlerBuilder
    {
        public IResponseHandler Build();
        public IResponseHandlerBuilder UseModule<T>(T Using) where T : IResponseHandlerModule;
        public IResponseHandlerBuilder UseAnother<T>(T Using);
    }
}
