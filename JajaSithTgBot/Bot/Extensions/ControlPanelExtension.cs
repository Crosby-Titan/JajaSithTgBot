using JajaSithTgBot.Bot.Panels;
using JajaSithTgBot.Bot.Panels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JajaSithTgBot.Bot.Extensions
{
    public static class ControlPanelExtension
    {
        public static void UseCommand(this ControlPanel panel, IPanelCommand panelCommand)
        {
            panel._Commands.TryAdd(panelCommand.Name, panelCommand.Command);
        }
    }
}
