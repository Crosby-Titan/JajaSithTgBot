using Bot.Panels.Commands;
using JajaSithTgBot.Implemented.Panels;

namespace JajaSithTgBot.Extensions
{
    public static class ControlPanelExtension
    {
        public static void UseCommand(this ControlPanel panel, IPanelCommand panelCommand)
        {
            panel._Commands.TryAdd(panelCommand.Name, panelCommand.Action);
        }
    }
}
