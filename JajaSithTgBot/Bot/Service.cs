using System.Text.Json.Serialization;

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
