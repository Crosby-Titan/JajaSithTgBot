using JajaSithTgBot.Bot;
using JajaSithTgBot.Bot.Content;
using JajaSithTgBot.Bot.Handlers;
using JajaSithTgBot.Bot.Panels;
using Telegram.Bot;

namespace JajaSithTgBot
{
    internal class Commands
    {
        public static IDictionary<string, IControlPanel.CommandDelegateHandler> GetAdminCommands()
        {
            return new Dictionary<string, IControlPanel.CommandDelegateHandler>()
            {
                {
                    "/post",
                    (botClient, id, isRedirect, redirectTo,requiredData) =>
                    {
                        IContentSelector selector = new DefaultContentSelector();
                        IPostHandler postHandler = new DefaultPostHandler();
                        string? command = requiredData as string;

                        if(command == null)
                            return;

                        string[] concreteData = command.Split(' ');

                        if(concreteData.Length <= 1)
                            return;

                        DateTime date = DateTime.Parse(concreteData[3]);

                        if (!selector.IsContentAvailable(concreteData[1], date))
                        {
                            botClient.SendTextMessageAsync(id, "New content is not available.");
                            return;
                        }

                        botClient.SendTextMessageAsync(id, "New content is available.");

                        Parallel.ForEach(selector.GetContent(concreteData[1], date), x =>
                        {
                            postHandler.PostAsync(botClient, MediaHelper.GetSortedMedia(x), redirectTo ?? throw new NullReferenceException());
                        });

                    }
                }
            };
        }

        public static IDictionary<string, IControlPanel.CommandDelegateHandler> GetUserCommands()
        {
            return new Dictionary<string, IControlPanel.CommandDelegateHandler>()
            {
                {
                    "/shop",
                    (botClient, id, isRedirect, redirectTo,requiredData) =>
                    {

                    }
                }
            };
        }
    }
}
