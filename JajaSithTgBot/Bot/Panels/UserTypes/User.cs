using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JajaSithTgBot.Bot.Panels.UserTypes
{
    public class User
    {
        private UserType _Type;
        private string _Username;

        public User(UserType type,string name)
        {
            _Type = type;
            _Username = name;
        }

        public string UserName { get { return _Username; } }
        public UserType Type { get { return _Type; } }

    }
}
