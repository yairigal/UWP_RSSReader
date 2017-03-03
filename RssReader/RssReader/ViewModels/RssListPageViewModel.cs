using RssReader.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssReader.ViewModels
{
    class RssListPageViewModel
    {
        ObservableCollection<string> list;
        private RssListPageModel model;

        public RssListPageViewModel()
        {
            this.model = new RssListPageModel(this);
            //list = model.getRssList();
            TEST_initList();
           
        }

        public ObservableCollection<string> List
        {
            get
            {
                return list;
            }

            set
            {
                list = value;
            }
        }

        private void TEST_initList()
        {
            List = new ObservableCollection<string>();
            List.Add("Yair");
            List.Add("Yaron");
        }
    }
}
