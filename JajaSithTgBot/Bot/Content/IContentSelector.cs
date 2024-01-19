using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JajaSithTgBot.Bot.Content
{
    public interface IContentSelector
    {
        bool IsContentAvailable(string cathegory, DateTime destinationTime);

        ICollection<ICollection<ContentPresenter>> GetContent(string cathegoryName, DateTime destinationTime);
    }
}
