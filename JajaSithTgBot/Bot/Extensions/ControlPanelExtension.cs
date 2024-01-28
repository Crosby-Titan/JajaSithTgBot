using JajaSithTgBot.Bot.Panels;
using JajaSithTgBot.Bot.Panels.Commands;

namespace JajaSithTgBot.Bot.Extensions
{
    public static class ControlPanelExtension
    {
        public static void UseCommand(this ControlPanel panel, IPanelCommand panelCommand)
        {
            panel._Commands.TryAdd(panelCommand.Name, panelCommand.Action);
        }
    }
}
