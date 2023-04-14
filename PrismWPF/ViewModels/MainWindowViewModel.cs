using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;

namespace PrismWPF.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public ObservableCollection<UIMenuObj> TreeMenuList { get { return _TreeMenuList; } set { SetProperty(ref _TreeMenuList, value); } }
        ObservableCollection<UIMenuObj> _TreeMenuList = new ObservableCollection<UIMenuObj>();
        public MainWindowViewModel(IContainerExtension container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
            Title = this.GetType().Name;
            CurrentRegionName = "BaseContentRegion";

            TreeMenuList = new ObservableCollection<UIMenuObj>
            {
                new UIMenuObj("用戶管理","ViewClient"),
                new UIMenuObj("結帳管理","ViewAccounting"),
                new UIMenuObj("OpenChat","ViewOpenChat"),
                new UIMenuObj("大項","ViewOpenChat") { SubMenu = new List<UIMenuObj>{ new UIMenuObj("Sub1", "ViewOpenChat"), new UIMenuObj("Sub2", "ViewOpenChat") } },
            };
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnPropertyChanged(args);
        }
    }
}
