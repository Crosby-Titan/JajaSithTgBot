using JajaSithTgBot.Bot.Panels.Commands;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;
using static JajaSithTgBot.Bot.Panels.IControlPanel;

namespace JajaSithTgBot.Bot.Panels
{
    public abstract class ControlPanel : IControlPanel
    {
        protected internal IDictionary<string, CommandDelegateHandler> _Commands;
        public abstract IEnumerable<BotCommand> GetBotCommands();
        public abstract void Process(ITelegramBotClient botClient, Message message, bool IsRequestResultRedirected = false, ChatId? redirectResponseTo = null);
        public abstract Task ProcessAsync(ITelegramBotClient botClient, Message message,bool IsRequestResultRedirected = false, ChatId? redirectResponseTo = null);

        public virtual void AddCommand(Command command)
        {
            if (_Commands.ContainsKey(command.Name))
                throw new ArgumentException(null, nameof(command));

            _Commands.Add(command.Name, command.Action);
        }

        public virtual void AddCommandRange(IDictionary<string, CommandDelegateHandler> commands)
        {
            foreach (var command in commands)
            {
                if (!_Commands.ContainsKey(command.Key))
                    _Commands.Add(command.Key, command.Value);
            }
        }

        public virtual void AddCommandRange(IEnumerable<Command> commands)
        {
            foreach (var command in commands)
            {
                if (!_Commands.ContainsKey(command.Name))
                    _Commands.Add(command.Name, command.Action);
            }
        }

        public virtual IDictionary<string, CommandDelegateHandler> GetDefaultCommands()
        {
            return new Dictionary<string, CommandDelegateHandler>()
            {
                { 
                    "/start",
                    async (bot,id,isRedirect,redirectTo,requiredData)=>
                    {
                        await bot.SendStickerAsync(id,new InputOnlineFile(new Uri(@"https://chpic.su/_data/stickers/f/Fan_01/Fan_01_002.webp?v=1689686703")));
                        await bot.SetMyCommandsAsync(GetBotCommands(),new BotCommandScopeAllPrivateChats());
                        await bot.GetMyCommandsAsync(scope: new BotCommandScopeAllPrivateChats());
                    } 
                }
            };
        }

    }
}
