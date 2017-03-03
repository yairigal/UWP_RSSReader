using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PL.Models;
using RssReader.Models;
using Windows.UI.Xaml.Controls;
using System.Windows.Input;
using RssReader.Views;

namespace PL.ViewModels
{
    class StartPageViewModel : INotifyPropertyChanged
    {
        StartPageModel model;
        private ICommand toggleBtnCmd;
        private ICommand navigateToPage;
        private bool isPaneOpen;
        private Page currentDisplayedPage;
        private Page listPage;
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ToggleBtnCmd
        {
            get
            {
                if (toggleBtnCmd == null)
                    toggleBtnCmd = new Command(TogglePane,()=>true);
                return toggleBtnCmd;
            }
        }
        public bool IsPaneOpen
        {
            get
            {
                return isPaneOpen;
            }
            set
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsPaneOpen"));
                isPaneOpen = value;
            }
        }

        public Page CurrentDisplayedPage
        {
            get
            {
                return currentDisplayedPage;
            }

            set
            {
                currentDisplayedPage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentDisplayedPage"));
            }
        }

        public ICommand NavigateToPage
        {
            get
            {
                if (navigateToPage == null)
                    navigateToPage = new Command(()=>Navigate(new YnetPage()), () => true);
                return navigateToPage;
            }
        }

        public Page ListPage
        {
            get
            {
                if (listPage == null)
                    listPage = new RssListPage();
                return listPage;
            }

            set
            {
                listPage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListPage"));
            }
        }

        public StartPageViewModel()
        {
            this.model = new StartPageModel(this);
            isPaneOpen = false;
        }

        private void TogglePane()
        {
            IsPaneOpen = !IsPaneOpen;
        }

        private void Navigate(Page page)
        {
            CurrentDisplayedPage = page;
        }
    }
}
