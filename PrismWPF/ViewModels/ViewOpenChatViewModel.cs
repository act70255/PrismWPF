using Checo.Service.Interface;
using OpenAI_API;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utility.Controls;
using Utility.Model;

namespace PrismWPF.ViewModels
{
    public class ViewOpenChatViewModel : BaseViewModel
    {
        ITESTService _testService;
        ITradeService _tradeService;
        OpenAIAPI chatAPI;
        public DelegateCommand AskCommand { get; private set; }
        public DelegateCommand TestCommand { get; private set; }


        public ObservableCollection<string> ChatList { get { return _ChatList; } set { SetProperty(ref _ChatList, value); } }
        ObservableCollection<string> _ChatList = new ObservableCollection<string>();

        public string AskString { get { return _AskString; } set { SetProperty(ref _AskString, value); } }
        string _AskString;

        public ViewOpenChatViewModel(IContainerExtension container, IRegionManager regionManager,ITESTService testservice, ITradeService tradeService)
        {
            _container = container;
            _regionManager = regionManager;
            _testService = testservice;
            _tradeService = tradeService;
            chatAPI = new OpenAI_API.OpenAIAPI("apikey");
            AskCommand = new DelegateCommand(async () =>
            {
                if (string.IsNullOrEmpty(AskString))
                    return;
                ChatList.Add(AskString);
                ChatList.Add(await chatAPI.Completions.GetCompletion(AskString));
                AskString = string.Empty;
            });
            TestCommand = new DelegateCommand(() =>
            {
                try
                {
                    var ss = _tradeService.Get();
                    testservice.AddProcess(() => { Task.Delay(5000); });
                    testservice.RunProcess();
                }
                catch (Exception)
                {
                    throw;
                }
            });
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnPropertyChanged(args);
            Debug.WriteLine($"OnPropertyChanged[{this.GetType().Name}] - {args.PropertyName}");
        }
    }
}
