using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RssReader.Models;

namespace RssReader.ViewModels
{
    class SearchPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ICommand search;

        private string query;

        public string Query
        {
            get
            {
                return query;
            }

            set
            {
                query = value;
                PropertyChanged?.Invoke(this,new PropertyChangedEventArgs("Query"));
            }
        }

        public ICommand Search
        {
            get
            {
                if(search == null)
                    search = new CommandTest(()=>RssListPageViewModel.searchExecute(query));
                return search;
            }
        }
    }
}
