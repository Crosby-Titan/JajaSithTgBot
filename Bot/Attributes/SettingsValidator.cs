using System.Reflection;

namespace Bot.Attributes
{
    public class SettingsValidator
    {
        public static bool Validate<TParent,TAttribute>(TParent obj)where TAttribute : Attribute
        {
            var type = typeof(TParent);

            MemberInfo[] members = type.GetMember(GetMemberName<TAttribute>(type), BindingFlags.Instance | BindingFlags.Public);

            foreach (var i in members)
            {
                var attr = i.GetCustomAttribute<TAttribute>();

                if(attr != null)
                {
                    RequiredInformation? info = (RequiredInformation?)((PropertyInfo)i).GetValue(obj);

                    if (string.IsNullOrEmpty(info?.ChannelID) || string.IsNullOrEmpty(info?.ApiKey))
                        return false;
                }
                
            }

            return true;
        }

        private static string GetMemberName<TAttribute>(Type type) where TAttribute : Attribute
        {
            var members = type.GetMembers(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var member in members)
            {
                var attr = member.GetCustomAttribute<TAttribute>();

                if (attr != null)
                {
                    return member.Name;
                }
            }

            return string.Empty;
        }
    }
}
