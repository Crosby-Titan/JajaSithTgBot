using System.Text.Json;

namespace JajaSithTgBot.Bot.JSON
{
    public class DataLoader : IDataLoader
    {
        public T? Load<T>(Stream json)
        {
            if (json == null) throw new ArgumentNullException(nameof(json));

            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
