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
        public YnetPageViewModel()
        {
            this.model = new YnetPageModel(this);
        }
    }
}
