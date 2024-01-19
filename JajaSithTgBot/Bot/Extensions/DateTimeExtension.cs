using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
