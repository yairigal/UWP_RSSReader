using PL;
using RssReader.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssReader.Models
{
    class YnetPageModel : BaseClass
    {
        private YnetPageViewModel ViewModel;

        public YnetPageModel(YnetPageViewModel vm)
        {
            this.ViewModel = vm;
        }
    }
}
