using RssReader.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssReader.ViewModels
{
    class YnetPageViewModel : INotifyPropertyChanged
    {
        private YnetPageModel model;

        public event PropertyChangedEventHandler PropertyChanged;
        private String link = "https://google.com";
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
        public YnetPageViewModel(string currentArticleLink)
        {
            this.Link = currentArticleLink;
            this.model = new YnetPageModel(this);
        }

        public void dismissLoading(object caller,EventArgs args) =>

            IsLoadingShown = false;

    }
}
