﻿using JajaSithTgBot.Bot.Content;
using JajaSithTgBot.Bot.Panels;
using JajaSithTgBot.Bot.Panels.UserTypes;
using System.Dynamic;
using System.Text.Json;
using System.Threading.Channels;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace JajaSithTgBot.Bot.Handlers
{
    public sealed class ResponseHandler: IResponseHandler
    {
        private readonly IPostHandler _PostHandler;
        private readonly IContentSelector _ContentSelector;
        private readonly ControlPanel _AdminPanel;
        private readonly ControlPanel _UserPanel;
        private ChatId? _ChatId;
        private ICollection<Panels.UserTypes.User> _SuperUsers;

        internal ResponseHandler(IPostHandler postHandler, IContentSelector selector,ControlPanel[] panels)
        {
            _PostHandler = postHandler ?? throw new ArgumentNullException(nameof(postHandler));
            _ContentSelector = selector ?? throw new ArgumentNullException(nameof(selector));
            _AdminPanel = panels[0] ?? throw new ArgumentNullException(nameof(panels));
            _UserPanel = panels[1] ?? throw new ArgumentNullException(nameof(panels));
            _SuperUsers = UserHelper.GetAdmins("telegram_bot_access_users.json");
        }

        public ChatId? ChatId { get { return _ChatId; } set => _ChatId = value ?? throw new NullReferenceException(); }

        public void Handle(ITelegramBotClient botClient,Message message)
        {
            
            if(_SuperUsers.Any(x=> x.UserName == $"{message.From.Username}"))
            {
                _AdminPanel.Process
            }

            var user = new Panels.UserTypes.User(message.From.IsBot ? UserType.Bot : UserType.User, message.From.Username);

            if(UserHelper.IsUser(UserType.User,user))
            {
                
            }
        }

        public async Task HandleAsync(ITelegramBotClient client, Message message)
        {
            await Task.Factory.StartNew(() =>
            {
                Handle(client, message);
            });
        }

        private void AdminCommands(ITelegramBotClient botClient, ChatId id, string message)
        {
            switch (message.ToLower())
            {

                case "check media":
                    if (_ContentSelector.IsContentAvailable("арт", DateTime.Now) || _ContentSelector.IsContentAvailable("видео", DateTime.Now))
                    {
                        botClient.SendTextMessageAsync(id, "New content is available.");
                    }
                    else
                        botClient.SendTextMessageAsync(id, "New content is not available.");
                    break;

                case "post media":

                    if (_ContentSelector.IsContentAvailable("арт", DateTime.Now))
                    {
                        Parallel.ForEach(_ContentSelector.GetContent("арт", DateTime.Now), x =>
                        {
                            _PostHandler.PostAsync(botClient, MediaHelper.GetSortedMedia(x), _ChatId);
                        });
                    }

                    if (_ContentSelector.IsContentAvailable("видео", DateTime.Now))
                    {
                        Parallel.ForEach(_ContentSelector.GetContent("видео", DateTime.Now), x =>
                        {
                            _PostHandler.PostAsync(botClient, MediaHelper.GetSortedMedia(x), _ChatId);
                        });
                    }

                    break;

                default:
                    botClient.SendTextMessageAsync(id, "Invalid command");
                    break;
            }
        }

        private void UserCommands(ITelegramBotClient botClient,ChatId id,string message)
        {

        }

        private static void SendReplyMarkup(ITelegramBotClient botClient, ChatId id, ReplyKeyboardMarkup markup)
        {
            botClient.SendTextMessageAsync(id, "Select some option", replyMarkup: markup);
        }

    }
}
