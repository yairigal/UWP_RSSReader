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
using BE;
using RssReader.Views;

namespace PL.ViewModels
{
    class StartPageViewModel : INotifyPropertyChanged
    {
        StartPageModel model;
        private ICommand toggleBtnCmd;
        private ICommand navigateToPage;
        private ICommand navigateToSearch;
        private bool isPaneOpen;
        private Page currentDisplayedPage;
        private RssListPage listPage;
        private RSSObject currentArticle = null;
        public static Func<RSSObject,object> articleSelected ;
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
            get { return navigateToPage ?? (navigateToPage = new Command(() => Navigate(new YnetPage(CurrentArticle?.Link)), () => true)); }
        }

        public RssListPage ListPage
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

        public RSSObject CurrentArticle
        {
            get
            {
                return currentArticle;
            }

            set
            {
                currentArticle = value;
                Navigate(new YnetPage(currentArticle.Link));
            }
        }

        public ICommand NavigateToSearch
        {
            get
            {
                if(navigateToSearch == null)
                    navigateToSearch = new Command(()=>Navigate(new SearchPage()),()=>true);
                return navigateToSearch;
            }
        }

        public StartPageViewModel()
        {
            this.model = new StartPageModel(this);
            isPaneOpen = false;
            articleSelected += onArticleSelected;
        }
        private object onArticleSelected(RSSObject obRssObject)
        {
            CurrentArticle = obRssObject;
            return null;
        }

        private void TogglePane() =>
            IsPaneOpen = !IsPaneOpen;

        private void Navigate(Page page) => 
            CurrentDisplayedPage = page;
    }
}
