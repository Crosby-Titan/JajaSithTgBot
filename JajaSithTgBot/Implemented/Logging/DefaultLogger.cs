using System.Text;
using Bot.Logging;
using JajaSithTgBot.Paths;
using JajaSithTgBot.Extensions;

namespace JajaSithTgBot.Implemented.Logging
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
