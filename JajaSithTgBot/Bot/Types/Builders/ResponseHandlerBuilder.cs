using JajaSithTgBot.Bot.Content;
using JajaSithTgBot.Bot.Handlers;
using JajaSithTgBot.Bot.Panels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace JajaSithTgBot.Bot.Types.Builders
{
    public class ResponseHandlerBuilder : IResponseHandlerBuilder
    {
        private IPostHandler? _PostHandler;
        private IContentSelector? _ContentSelector;
        private List<IControlPanel?> _Panels;
        private  ChatId? _ChatId;

        public ResponseHandlerBuilder()
        {
            _Panels = new List<IControlPanel?>();
        }

        public IResponseHandler Build()
        {
            return new ResponseHandler(_PostHandler, _ContentSelector, _Panels.ToArray())
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
            if(Using == null)
                throw new ArgumentNullException(nameof(Using),string.Empty);

            switch(Using)
            {
                case IPostHandler PostHandler:
                    _PostHandler = PostHandler;
                    break;
                case IContentSelector ContentSelector: 
                    _ContentSelector = ContentSelector;
                    break;
                case IControlPanel panel:

                    _Panels.Add(panel);

                    break;
                default:
                    break;
            }

            return this;
        }
    }
}
