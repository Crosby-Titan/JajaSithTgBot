using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JajaSithTgBot.Bot.Logging
{
    public interface ILogFormatter
    {
        public object Format(object message);
    }
}
