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

namespace RssReader.ViewModels
{
    class RssListPageViewModel : INotifyPropertyChanged
    {
        ObservableCollection<RSSObject> list;
        private RssListPageModel model;
        public static Func<string, object> searchExecute;

        private RSSObject currentItemSelected;

        public RssListPageViewModel()
        {
            this.model = new RssListPageModel(this);
            searchExecute+= SearchExecute;
            list = model.getRssObjects("Ynet");
            //TEST_initList();
            model.saveRssList(list);
        }

        private object SearchExecute(string s)
        {
            list = model.search(s);
            return null;
        }

        public ObservableCollection<RSSObject> List
        {
            get
            {
                return list;
            }
        }

        public RSSObject CurrentItemSelected
        {
            get { return currentItemSelected; }
            set { currentItemSelected = value;
                StartPageViewModel.articleSelected(currentItemSelected);
            }
        }

        private void TEST_initList()
        {
            list = new ObservableCollection<RSSObject>();
            List.Add(new RSSObject("חדשות","חדשות","https://google.com",null));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
