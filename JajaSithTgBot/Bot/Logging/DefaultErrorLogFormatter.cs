using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JajaSithTgBot.Bot.Logging
{
    public class DefaultErrorLogFormatter : ILogFormatter
    {
        public object Format(object message)
        {
            Exception? ex = message as Exception;

            if (ex == null)
                return message.ToString() ?? throw new ArgumentNullException(nameof(message));

            StringBuilder ErrorMessage = new StringBuilder();

            ErrorMessage.Append($"\n[{DateTime.Now.ToShortTimeString()}] : ");
            ErrorMessage.Append($"\t\tAn exception has occured - {ex.Message}\n");
            ErrorMessage.Append($"\t\tSource : {ex.Source}");
            ErrorMessage.Append($"\t\tStack trace : {ex.StackTrace}");
            ErrorMessage.AppendLine(new string('-', 20));

            return ErrorMessage.ToString();
        }
    }
}
