using System.Text;

namespace JajaSithTgBot.Bot.Logging
{
    public class DefaultErrorLogFormatter : ILogFormatter
    {
        public object Format(object message)
        {
            if (message is not Exception ex)
                return message.ToString() ?? throw new ArgumentNullException(nameof(message));

            StringBuilder ErrorMessage = new StringBuilder();

            ErrorMessage.Append($"\n[{DateTime.Now.ToShortTimeString()}] : ");
            ErrorMessage.AppendLine($"An exception has occured - {ex.Message}");
            ErrorMessage.AppendLine($" Source : {ex.Source}");
            ErrorMessage.AppendLine($" Stack trace : {ex.StackTrace}");
            ErrorMessage.AppendLine(new string('-', 100));

            return ErrorMessage.ToString();
        }
    }
}
