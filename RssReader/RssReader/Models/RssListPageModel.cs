using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using PL;
using RssReader.ViewModels;

namespace RssReader.Models
{
    class RssListPageModel : BaseClass
    {
        private RssListPageViewModel viewModel;

        public RssListPageModel(RssListPageViewModel rssListPageViewModel)
        {
            this.viewModel = rssListPageViewModel;
        }

        public ObservableCollection<RSSObject> getRssObjects(string Title)
        {
            return Bl.getRssFeed();
        }

        public void saveRssList(ObservableCollection<RSSObject> list)
        {
            Bl.saveRssObjects(list);
        }

        public ObservableCollection<RSSObject> search(string s)
        {
            return Bl.SearchRssTitle(s);
        }
    }
}
