using JajaSithTgBot.Bot.Attributes;
using System.Text.Json.Serialization;

namespace JajaSithTgBot.Bot
{
    public class TelegramSettings
    {
        [JsonPropertyName("telegram_info")]
        [SettingsValidation]
        public RequiredInformation Information { get; set; }
    }

    public struct RequiredInformation
    {
        [JsonPropertyName("api_key")]
        public string ApiKey { get; set; }

        [JsonPropertyName("channel_id")]
        public string ChannelID { get; set; }
    }
}
