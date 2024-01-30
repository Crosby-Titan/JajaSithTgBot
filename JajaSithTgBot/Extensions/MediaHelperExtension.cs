using Bot;
using Bot.Types.Factories;
using Bot.Types.Reflection;
using JajaSithTgBot.Implemented.Parsing;
using JajaSithTgBot.Paths;
using System.Dynamic;
using System.Text.Json;
using Telegram.Bot.Types;

namespace JajaSithTgBot.Extensions
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
