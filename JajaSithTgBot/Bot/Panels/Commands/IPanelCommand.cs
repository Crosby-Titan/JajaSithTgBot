using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JajaSithTgBot.Bot.Panels.Commands
{
    public interface IPanelCommand
    {
        public string Name { get; set; }
        public IControlPanel.CommandDelegateHandler Action { get; set; }
    }
}
