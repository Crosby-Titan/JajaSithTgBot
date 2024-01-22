using System.Dynamic;
using System.Text.Json;

namespace JajaSithTgBot.Bot.Panels.UserTypes
{
    public static class UserHelper
    {
        public static bool IsUser(UserType target, User user)
        {
            return user.Type == target;
        }

        public static ICollection<User> GetAdmins(string file)
        {
            dynamic? value = JsonSerializer.Deserialize<ExpandoObject>(System.IO.File.OpenRead(Path.Combine(Paths.PathWorker.Telegram, file)));

            List<string> admins = JSON.JsonParser.GetSpecifiedData(value?.allowed_users) ?? new List<string>();

            return admins.Select(x => new User(UserType.Admin, x)).ToList();
        }
    }
}
