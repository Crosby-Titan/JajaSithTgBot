using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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
