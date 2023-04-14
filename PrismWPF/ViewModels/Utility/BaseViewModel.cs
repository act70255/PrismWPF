using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Text.Json;
using System.Windows.Input;
using Prism.Commands;
using System.Linq;

namespace PrismWPF.ViewModels
{
    public class BaseViewModel : BindableBase, INavigationAware
    {
        protected IContainerExtension _container;
        protected IRegionManager _regionManager;
        public string CurrentRegionName { get; set; }
        public ICommand NavigateCommand { get; private set; }
        public ICommand BackCommand { get; private set; }

        public string Title { get { return _title; } set { SetProperty(ref _title, value); } }
        private string _title;
        public Visibility CanGoBack { get { return _CanGoBack; } set { SetProperty(ref _CanGoBack, value); } }
        private Visibility _CanGoBack;

        public BaseViewModel()
        {
            NavigateCommand = new DelegateCommand<object>((obj) =>
            {
                if (obj == null)
                    return;
                else if (obj is string navigatePath)
                    Navigation(navigatePath);
                else if (obj is UIMenuObj menuObj)
                {
                    if (menuObj.SubMenu.Any())
                    {
                        menuObj.IsExpand = !menuObj.IsExpand;
                    }
                    else
                    {
                        Navigation(menuObj.NavigationUrl);
                    }
                }
            });

            BackCommand = new DelegateCommand(() =>
            {
                if (!string.IsNullOrEmpty(CurrentRegionName) && _regionManager.Regions[CurrentRegionName].NavigationService.Journal.CanGoBack)
                {
                    _regionManager?.Regions[CurrentRegionName].NavigationService.Journal.GoBack();
                }
            });
        }

        protected virtual void Navigation(string navigatePath, NavigationParameters naviParams = null)
        {
            if (string.IsNullOrEmpty(navigatePath) || _regionManager == null)
                return;

            if (naviParams == null)
                naviParams = new NavigationParameters { { "BaseRegionName",CurrentRegionName } };

            if (!naviParams.ContainsKey("BaseRegionName"))
                naviParams.Add("BaseRegionName", CurrentRegionName);

            _regionManager?.RequestNavigate(CurrentRegionName, navigatePath, naviParams);
        }

        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters.ContainsKey("BaseRegionName"))
                CurrentRegionName = navigationContext.Parameters["BaseRegionName"] as string;

            //if (_regionManager != null)
            //    Debug.WriteLine($"[{CurrentRegionName}]{_regionManager.Regions[CurrentRegionName].ActiveViews}");
        }

        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}
