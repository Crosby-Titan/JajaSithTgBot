using System.Text.Json;
using Bot.JSON;

namespace JajaSithTgBot.Implemented.Parsing
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
