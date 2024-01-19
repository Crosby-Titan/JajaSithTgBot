using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JajaSithTgBot.Bot.JSON
{
    public interface IParser
    {
        public dynamic Parse(string json);
        public dynamic Parse(Stream json);
    }

}
