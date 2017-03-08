using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace PL
{
    public class BL : BaseClass, IBL
    {
        public ObservableCollection<RSSObject> getRssFeed()
        {
            return new ObservableCollection<RSSObject>(dal.getListFromFeed());
        }

        public void saveRssObjects(ObservableCollection<RSSObject> list)
        {
            Task.Run(() =>
            {
                foreach (var rss in list)
                    dal.saveRSSAsync(rss);

            });

        }

        public ObservableCollection<RSSObject> SearchRssTitle(string title)
        {
            ObservableCollection<RSSObject> collection = new ObservableCollection<RSSObject>(dal.getRss(title));
            return collection;
        }
    }
}
