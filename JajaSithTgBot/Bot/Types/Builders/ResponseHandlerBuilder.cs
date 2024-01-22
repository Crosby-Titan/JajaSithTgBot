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
        private  IControlPanel? _AdminPanel;
        private  IControlPanel? _UserPanel;
        [Required]
        private  ChatId? _ChatId;

        public IResponseHandler Build()
        {
            _PostHandler ??= new DefaultPostHandler();
            _ContentSelector ??= new DefaultContentSelector();
            _AdminPanel ??= new AdminPanel(new Dictionary<string, IControlPanel.CommandDelegateHandler>(){
                
            });
            _UserPanel ??= new UserPanel(new Dictionary<string, IControlPanel.CommandDelegateHandler>()
            {

            });

            return new ResponseHandler(_PostHandler, _ContentSelector, new[] { _AdminPanel, _UserPanel })
            {
                ChatId = _ChatId
            };
        }

        public IResponseHandlerBuilder UseAnother<T>(T Using)
        {
            if (Using == null)
                throw new ArgumentNullException(nameof(Using), string.Empty);

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
                    
                    if(panel.GetType() == typeof(AdminPanel))
                        _AdminPanel = panel;
                    else if(panel.GetType() == typeof(UserPanel))
                        _UserPanel = panel;

                    break;
                default:
                    break;
            }

            return this;
        }
    }
}
