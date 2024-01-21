using JajaSithTgBot.Bot;
using JajaSithTgBot.Bot.Logging;

namespace JajaSithTgBot
{
    internal class Program
    {
        private static readonly ILogger Logger = new DefaultLogger(); 
        private static readonly ILogFormatter LogFormatter = new DefaultErrorLogFormatter();
        static async Task Main(string[] args)
        {
            try
            {
                await BotHelper.Start(BotHelper.LoadSettigs("telegram_info.json"));

                Console.ReadLine();

                BotHelper.Stop();
            }
            catch (Exception ex)
            {
                Logger.Log(LogFormatter.Format(ex));
            }
        }
    }
}