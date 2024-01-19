using JajaSithTgBot.Bot.Content;
using System.Dynamic;
using System.Text.Json;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace JajaSithTgBot.Bot.Handlers
{
    public class ResponseHandler
    {
        private readonly IPostHandler _PostHandler;
        private readonly IContentSelector _ContentSelector;
        private readonly ChatId _ChatId;
        private List<string>? _SuperUsers;

        public ResponseHandler(IPostHandler postHandler, IContentSelector selector, ChatId channel)
        {
            _PostHandler = postHandler ?? throw new ArgumentNullException(nameof(postHandler));
            _ContentSelector = selector ?? throw new ArgumentNullException(nameof(selector));
            _ChatId = channel ?? throw new ArgumentNullException(nameof(channel));
            LoadSuperUsers();
        }

        public void Handle(ITelegramBotClient botClient, ChatId id, string message, string username)
        {
            if (!IsUserAdnim(username))
            {
                botClient.SendTextMessageAsync(id, "Access denied");
                return;
            }

            AdminCommands(botClient, id, message);

            SendReplyMarkUp(botClient, id, GetAdminKeyBoardPanel());
        }

        private void AdminCommands(ITelegramBotClient botClient, ChatId id, string message)
        {
            switch (message.ToLower())
            {
                case "/start":
                    break;
                case "check media":
                    if (_ContentSelector.IsContentAvailable("арт", DateTime.Now) || _ContentSelector.IsContentAvailable("видео", DateTime.Now))
                    {
                        botClient.SendTextMessageAsync(id, "New content is available.");
                    }
                    else
                        botClient.SendTextMessageAsync(id, "New content is not available.");
                    break;
                case "post media":

                    //if (_ContentSelector.IsContentAvailable("арт", DateTime.Now))
                    //    goto case "photo";

                    if (_ContentSelector.IsContentAvailable("видео", DateTime.Now))
                        goto case "video";

                    break;
                case "photo":
                    Parallel.ForEach(_ContentSelector.GetContent("арт", DateTime.Now), x =>
                    {
                        _PostHandler.PostAsync(botClient, MediaHelper.GetSortedMedia(x), _ChatId);
                    });
                    break;
                case "video":
                    Parallel.ForEach(_ContentSelector.GetContent("видео", DateTime.Now), x =>
                    {
                        _PostHandler.PostAsync(botClient, MediaHelper.GetSortedMedia(x), _ChatId);
                    });
                    break;
                default:
                    botClient.SendTextMessageAsync(id, "Invalid command");
                    break;
            }
        }

        private bool IsUserAdnim(string username)
        {
            if (_SuperUsers == null) return false;

            if (_SuperUsers.Contains(username)) return true;

            return false;
        }

        private void LoadSuperUsers()
        {
            dynamic? value = JsonSerializer.Deserialize<ExpandoObject>(System.IO.File.OpenRead(Path.Combine(Paths.PathWorker.Telegram, "telegram_bot_access_users.json")));

            _SuperUsers = JSON.JsonParser.GetSpecifiedData(value?.allowed_users) ?? new List<string>();
        }

        protected internal static ReplyKeyboardMarkup GetAdminKeyBoardPanel()
        {
            return new ReplyKeyboardMarkup(new[]
            {
                new KeyboardButton[] { new KeyboardButton("Check media") },
                new KeyboardButton[] { new KeyboardButton("Post media") }
            });
        }

        private static void SendReplyMarkUp(ITelegramBotClient botClient, ChatId id, ReplyKeyboardMarkup markup)
        {
            botClient.SendTextMessageAsync(id, "Select some option", replyMarkup: markup);
        }
    }
}
