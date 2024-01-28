using JajaSithTgBot.Bot.Panels;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace JajaSithTgBot.Bot.Handlers
{
    public sealed class ResponseHandler: IResponseHandler
    {
        private readonly ControlPanel _AdminPanel;
        private readonly ControlPanel _UserPanel;
        private ChatId? _ChatId;

        internal ResponseHandler(ControlPanel[] panels)
        {
            _AdminPanel = panels[0] ?? throw new ArgumentNullException(nameof(panels));
            _UserPanel = panels[1] ?? throw new ArgumentNullException(nameof(panels));
        }

        public ChatId? ChatId { get { return _ChatId; } set => _ChatId = value ?? throw new NullReferenceException(); }

        public void Handle(ITelegramBotClient botClient,Message message)
        {
            if (message == null)
                return;

            if (message.Chat.Type != Telegram.Bot.Types.Enums.ChatType.Private)
                return;

            if (!UserHelper.IsUserAdmin(message.From))
            {
                _UserPanel.Process(botClient, message);
                return;
            }

            _AdminPanel.Process(botClient, message,true,_ChatId);
        }

        public async Task HandleAsync(ITelegramBotClient client, Message message)
        {
            await Task.Factory.StartNew(() =>
            {
                Handle(client, message);
            });
        }
    }
}
