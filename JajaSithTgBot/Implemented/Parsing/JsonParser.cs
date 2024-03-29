﻿using System.Dynamic;
using System.Text.Json;

namespace JajaSithTgBot.Implemented.Parsing
{
    public class JsonParser
    {
        public static dynamic? Parse(string json)
        {
            return GetSpecifiedData(JsonSerializer.Deserialize<ExpandoObject>(json));
        }

        public static dynamic? Parse(Stream json)
        {
            return GetSpecifiedData(JsonSerializer.Deserialize<ExpandoObject>(json));
        }

        public static dynamic? GetSpecifiedData(dynamic? data)
        {
            if (data.ValueKind == JsonValueKind.Null || data.ValueKind == JsonValueKind.Undefined)
                throw new ArgumentNullException(nameof(data));

            switch (data.ValueKind)
            {
                case JsonValueKind.String:
                    {
                        foreach (var ch in $"{data}")
                        {
                            if (!char.IsDigit(ch))
                            {
                                return $"{data}";
                            }
                        }

                        goto case JsonValueKind.Number;
                    }
                case JsonValueKind.Number:
                    return int.Parse($"{data}");
                case JsonValueKind.True:
                case JsonValueKind.False:
                    return bool.Parse($"{data}");
                case JsonValueKind.Object:
                    return data.Value;
                case JsonValueKind.Array:
                    return JsonSerializer.Deserialize<List<string>>(data);
                default:
                    return string.Empty;
            }
        }
    }
}