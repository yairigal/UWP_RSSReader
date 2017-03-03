using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RssReader.ViewModels;

namespace RssReader.Models
{
    class RssListPageModel
    {
        private RssListPageViewModel viewModel;

        public RssListPageModel(RssListPageViewModel rssListPageViewModel)
        {
            this.viewModel = rssListPageViewModel;
        }
    }
}
