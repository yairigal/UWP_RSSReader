using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace PL
{
    public interface IBL
    {
        ObservableCollection<RSSObject> getRssFeed();
        void saveRssObjects(ObservableCollection<RSSObject> list);
        ObservableCollection<RSSObject> SearchRssTitle(string title);
    }
}
