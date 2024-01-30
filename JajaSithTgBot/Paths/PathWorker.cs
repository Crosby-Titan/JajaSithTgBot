using JajaSithTgBot.Extensions;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JajaSithTgBot.Paths
{
    public class PathWorker
    {
        public static string? ApplicationPath { get; private set; }
        public static string? Json { get; private set; }
        public static string? Logs { get; private set; }
        public static string? Content { get; private set; }
        public static string? Telegram { get; private set; }
        public static string? Media { get; private set; }

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
            Media = Path.Combine(ApplicationPath, "Data\\Types\\Media");
        }

        public static void RenameDirectory(DirectoryInfo? directory, string? newName)
        {
            if (directory == null || newName == null) return;

            FileSystem.RenameDirectory(directory.FullName, newName);
        }
    }
}
