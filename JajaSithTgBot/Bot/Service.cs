using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JajaSithTgBot.Bot
{
    public class Service
    {
        [JsonPropertyName("telegram_info")]
        public TelegramBotInformation Information { get; set; }
    }

    public struct TelegramBotInformation
    {
        [JsonPropertyName("api_key")]
        public string ApiKey { get; set; }

        [JsonPropertyName("channel_id")]
        public string ChannelID { get; set; }
    }
}
