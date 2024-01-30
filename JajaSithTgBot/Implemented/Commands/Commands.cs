using Bot.Content;
using Bot.Handlers;
using Bot.Panels;
using JajaSithTgBot.Implemented.Handlers;
using Telegram.Bot;

namespace JajaSithTgBot.Implemented.Commands
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
                        if(requiredData is not string command)
                            return;

                        string[] concreteData = command.Split(' ');

                        if(concreteData.Length <= 1)
                            return;

                        IContentSelector selector = new DefaultContentSelector();
                        IPostHandler postHandler = new DefaultPostHandler();

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
