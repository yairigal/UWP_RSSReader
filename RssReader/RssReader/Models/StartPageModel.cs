using PL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace PL.Models
{
    class StartPageModel : BaseClass
    {
        private StartPageViewModel vm;

        public StartPageModel(StartPageViewModel vm)
        {
            this.vm = vm;
        }

        public void search(string query)
        {
            throw new NotImplementedException();
        }
    }
}
