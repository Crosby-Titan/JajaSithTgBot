using JajaSithTgBot.Bot.Content;
using JajaSithTgBot.Bot.JSON;
using JajaSithTgBot.Bot.Paths;
using JajaSithTgBot.Bot.Types.Factories;
using JajaSithTgBot.Bot.Types.Reflection;
using System.Dynamic;
using System.Text.Json;
using Telegram.Bot.Types;

namespace JajaSithTgBot.Bot.Extensions
{
    public static class MediaHelperExtension
    {
        public static InputMediaBase? CreateMedia(this MediaHelper helper,ContentPresenter content)
        {
            ICollection<string> mediaList = GetSupportedMedia("media_type_available.json");

            if (mediaList.Contains(content.MediaType.ToString()))
            {
                var factory = ClassReflection.CreateClass(content.MediaType.ToString() + nameof(MediaFactory), null,Array.Empty<Type>()) as MediaFactory;

                return factory?.CreateMedia(content);
            }
                    

            return null;
        }

        private static ICollection<string> GetSupportedMedia(string file)
        {
            dynamic? obj = JsonSerializer.Deserialize<ExpandoObject>(System.IO.File.OpenRead(Path.Combine(PathWorker.Media, file)));

            return JsonParser.GetSpecifiedData(obj?.medias);
        }
    }
}
