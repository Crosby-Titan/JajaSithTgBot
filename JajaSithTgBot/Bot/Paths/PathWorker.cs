using JajaSithTgBot.Bot.Extensions;
using System.Text;

namespace JajaSithTgBot.Bot.Paths
{
    public class PathWorker
    {
        public static string? ApplicationPath { get; private set; }
        public static string? Json { get; private set; }
        public static string? Logs { get; private set; }
        public static string? Content { get; private set; }
        public static string? Telegram { get; private set; }

        static PathWorker() { InitializePaths(); }

        public static void InitializePaths()
        {
            var sb = new StringBuilder(Environment.CurrentDirectory);

            ApplicationPath = sb.Replace("bin", "_")
                .Remove(sb.IndexOf('_'))
                .ToString();

            Json = Path.Combine(ApplicationPath, "Data\\JSON");
            Logs = Path.Combine(ApplicationPath, "Data\\Logs");
            Content = Path.Combine(ApplicationPath, "Data\\Content");
            Telegram = Path.Combine(ApplicationPath, "Data\\Telegram");
        }
    }
}
