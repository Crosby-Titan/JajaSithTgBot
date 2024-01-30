using JajaSithTgBot.Implemented.Parsing;
using System.Dynamic;
using System.Text.Json;

namespace JajaSithTgBot
{
    public static class UserHelper
    {
        private static ICollection<string> _Admins;

        static UserHelper()
        {
            _Admins = GetAdmins("telegram_bot_access_users.json");
        }

        public static bool IsUserAdmin(Telegram.Bot.Types.User user)
        {
            return _Admins.Any(admin => admin == $"@{user.Username}");
        }

        public static ICollection<string> GetAdmins(string file)
        {
            dynamic? value = JsonSerializer.Deserialize<ExpandoObject>(File.OpenRead(Path.Combine(Paths.PathWorker.Telegram, file)));

            List<string> admins = JsonParser.GetSpecifiedData(value?.allowed_users) ?? new List<string>();

            return admins;
        }
    }
}
