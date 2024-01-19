namespace JajaSithTgBot.Bot.Extensions
{
    public static class DateTimeExtension
    {
        public static string ToShortDateString(this DateTime dateTime,char dateSeparator, DateTimeKind kind = DateTimeKind.Local)
        {
            return DateTime.SpecifyKind(dateTime, kind).ToShortDateString().Replace('.', dateSeparator);
        }
    }
}
