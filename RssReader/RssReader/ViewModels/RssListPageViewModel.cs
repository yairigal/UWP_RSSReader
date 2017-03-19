using RssReader.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using PL.ViewModels;
using RssReader.Views;

namespace RssReader.ViewModels
{
    class RssListPageViewModel : INotifyPropertyChanged
    {
        ObservableCollection<RssItem> list;
        private ObservableCollection<RSSObject> rssList;
        private RssListPageModel model;
        public static Func<string, object> searchExecute;
        private RssItem currentItemSelected;

        public RssListPageViewModel()
        {
            this.model = new RssListPageModel(this);
            searchExecute+= SearchExecute;
            RssList = model.getRssObjects("Ynet");
            setUpUserControlList();
            //TEST_initList();
            model.saveRssList(RssList);
        }

        private void setUpUserControlList()
        {
            list = new ObservableCollection<RssItem>();
            foreach (var rssObject in RssList)           
                list.Add(new RssItem(rssObject));
            List = list;
        }

        private object SearchExecute(string s)
        {
            RssList = model.search(s);
            return null;
        }

        public ObservableCollection<RssItem> List
        {
            set { list = value; PropertyChanged?.Invoke(this,new PropertyChangedEventArgs("List")); }
            get
            {
                return list;
            }
        }

        public RssItem CurrentItemSelected
        {
            get { return currentItemSelected; }
            set { currentItemSelected = value;
                StartPageViewModel.articleSelected(currentItemSelected.CurrentRss);
            }
        }

        public ObservableCollection<RSSObject> RssList
        {
            get
            {
                return rssList;
            }

            set
            {
                rssList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RssList"));
                setUpUserControlList();
            }
        }

        private void TEST_initList()
        {
            RssList = new ObservableCollection<RSSObject>();
            rssList.Add(new RSSObject("חדשות","חדשות","https://google.com",null));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
