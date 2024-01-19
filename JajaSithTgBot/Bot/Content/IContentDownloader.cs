using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JajaSithTgBot.Bot.Content
{
    public interface IContentDownloader
    {
        public Task<ICollection<ContentPresenter>> LoadContentAsync(string path);
        public ICollection<ContentPresenter> LoadContent(string path);
    }
}
