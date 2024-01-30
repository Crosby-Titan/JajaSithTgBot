using Bot.Handlers;
using Newtonsoft.Json;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace JajaSithTgBot.Serverless
{
    public class Entry
    {
        private readonly ITelegramBotClient _BotClient;
        private readonly IHandler _Handler;
        private readonly CancellationTokenSource _TokenSource;
        private readonly JsonSerializer _Serializer;

        public Entry(ITelegramBotClient bot, IHandler handler)
        {
            _BotClient = bot ?? throw new ArgumentNullException(nameof(bot)); 
            _Handler = handler ?? throw new ArgumentNullException(nameof(handler));
            _TokenSource = new CancellationTokenSource();
            _Serializer = JsonSerializer.CreateDefault();
        }

        public async Task<string> FunctionHandler(string request)
        {
            try
            {
                Update update = GetUpdate(request);

                if (update.Type != Telegram.Bot.Types.Enums.UpdateType.Message)
                    return request;

                await _Handler.HandleUpdateAsync(_BotClient, update, _TokenSource.Token);
            }
            catch(Exception ex)
            {
                await _Handler.HandleErrorAsync(_BotClient,ex,_TokenSource.Token);
            }
            
            return request;
        }

        private Update GetUpdate(string request)
        {
            using Stream stream = new MemoryStream();

            stream.Write(Encoding.UTF8.GetBytes(request));

            return _Serializer.Deserialize<Update>(new JsonTextReader(new StreamReader(stream)));
        }

        public void Stop()
        {
            _TokenSource.Cancel();
        }
    }
}