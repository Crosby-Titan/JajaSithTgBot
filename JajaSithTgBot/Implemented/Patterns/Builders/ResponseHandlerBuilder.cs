using Bot.Handlers;
using Bot.Panels;
using Bot.Types.Builders;
using JajaSithTgBot.Implemented.Handlers;
using JajaSithTgBot.Implemented.Panels;
using Telegram.Bot.Types;

namespace JajaSithTgBot.Implemented.Patterns.Builders
{
    public class ResponseHandlerBuilder : IResponseHandlerBuilder
    {
        private List<ControlPanel?> _Panels;
        private ChatId? _ChatId;

        public ResponseHandlerBuilder()
        {
            _Panels = new List<ControlPanel?>();
        }

        public IResponseHandler Build()
        {
            return new ResponseHandler(_Panels.ToArray())
            {
                ChatId = _ChatId
            };
        }

        public IResponseHandlerBuilder UseAnother<T>(T Using)
        {
            switch (Using)
            {
                case ChatId chat:
                    _ChatId = chat;
                    break;
                default:
                    break;
            }

            return this;
        }

        public IResponseHandlerBuilder UseModule<T>(T Using) where T : IResponseHandlerModule
        {
            if (Using == null)
                throw new ArgumentNullException(nameof(Using), string.Empty);

            switch (Using)
            {
                case IControlPanel panel:

                    _Panels.Add((ControlPanel)panel);

                    break;
                default:
                    break;
            }

            return this;
        }
    }
}
