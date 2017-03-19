using RssReader.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace RssReader.ViewModels
{
    class YnetPageViewModel : INotifyPropertyChanged
    {
        private YnetPageModel model;

        public event PropertyChangedEventHandler PropertyChanged;
        private String link;
        public static Func<RSSObject, object> onArticleSelected;
        private bool isLoadingShown = true;

        public string Link
        {
            get
            {
                return link;
            }

            set
            {
                link = value;
                PropertyChanged?.Invoke(this,new PropertyChangedEventArgs("Link"));
            }
        }

        public bool IsLoadingShown
        {
            get
            {
                return isLoadingShown;
            }

            set
            {
                isLoadingShown = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsLoadingShown"));
            }
        }

        public YnetPageViewModel() { }

        public YnetPageViewModel(string currentArticleLink = "")
        {
            this.Link = currentArticleLink;
            this.model = new YnetPageModel(this);
            onArticleSelected += OnArticleSelected;
        }

        private object OnArticleSelected(RSSObject rssObject)
        {
            Link = rssObject.Link;
            return null;
        }

        public void dismissLoading(object caller,EventArgs args) =>

            IsLoadingShown = false;

    }
}
