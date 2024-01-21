using System.Text;
using JajaSithTgBot.Bot.Paths;
using JajaSithTgBot.Bot.Extensions;

namespace JajaSithTgBot.Bot.Logging
{
    public class DefaultLogger : ILogger
    {
        public void Log(object message)
        {
            using Stream stream = new FileStream(Path.Combine(PathWorker.Logs, $"Log-{DateTime.Now.ToShortDateString('-')}.txt"), FileMode.OpenOrCreate);

            stream.Position = stream.Seek(stream.Length, SeekOrigin.Begin);
            stream.Write(Encoding.Unicode.GetBytes($"{message}"));
        }
    }
}
