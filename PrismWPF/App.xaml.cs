using Checo.Repository.Interface;
using Checo.Service;
using Checo.Service.Interface;
using Prism.Ioc;
using PrismWPF.ViewModels;
using PrismWPF.Views;
using System.Windows;
using Checo.Repository;
using AutoMapper;
using Checo.Service.Utility;

namespace PrismWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainWindow, MainWindowViewModel>();
            containerRegistry.RegisterForNavigation<ViewAccounting, ViewAccountingViewModel>();
            containerRegistry.RegisterForNavigation<ViewClient, ViewClitntViewModel>();
            containerRegistry.RegisterForNavigation<ViewOpenChat, ViewOpenChatViewModel>();

            containerRegistry.Register(typeof(IRepository<>), typeof(Repository<>));
            containerRegistry.RegisterSingleton<IUtilityService, UtilityService>();
            containerRegistry.RegisterSingleton<ITradeService, TradeService>();
            containerRegistry.RegisterSingleton<IToolService, ToolService>();
            containerRegistry.RegisterSingleton<IMsSQLRepository, MsSQLRepository>();
            containerRegistry.RegisterSingleton<ITESTService, TESTService>();
            containerRegistry.RegisterSingleton<IGoogleMapService, GoogleMapService>();
            
        }
    }
}
