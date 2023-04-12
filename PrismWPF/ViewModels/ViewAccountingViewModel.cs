using Checo.Repository.Entity;
using Checo.Service.Interface;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace PrismWPF.ViewModels
{
    public class ViewAccountingViewModel : BaseViewModel
    {
        IToolService _toolService;
        public string Path { get { return _Path; } set { SetProperty(ref _Path, value); } }
        string _Path;
        public string Result { get { return _Result; } set { SetProperty(ref _Result, value); } }
        string _Result;
        public ObservableCollection<string> Lists { get { return _Lists; } set { SetProperty(ref _Lists, value); } }
        ObservableCollection<string> _Lists = new ObservableCollection<string>();

        public ICommand RunCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ViewAccountingViewModel(IContainerExtension container, IRegionManager regionManager, IToolService toolService)
        {
            _container = container;
            _regionManager = regionManager;
            _toolService = toolService;
            Path = @"D:\IAM_V1_Logging.cmn_bond_price.xlsx";
            Lists = new ObservableCollection<string> { "1", "2", "3", "4" };
            RunCommand = new DelegateCommand(() =>
            {
                _toolService.ImportExcelPrice(Path);
                //_toolService.AnalysicQueryFile(@"C:\Downloads\Data\投資報表初始資料");
                //Result = "RunCommand : " + _toolService.ImportExcel(Path);
            });
            AddCommand = new DelegateCommand(() =>
            {
                Lists.Add(DateTime.Now.ToString());
            });
        }

        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
            base.OnNavigatedFrom(navigationContext);
        }
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
        }
    }
}
