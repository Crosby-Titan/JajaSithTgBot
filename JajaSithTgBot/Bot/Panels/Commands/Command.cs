using JajaSithTgBot.Bot.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JajaSithTgBot.Bot.Panels.Commands
{
    public class Command : IPanelCommand
    {
        public string Name { get; set; }
        public IControlPanel.CommandDelegateHandler Action { get; set; }
    }
}
