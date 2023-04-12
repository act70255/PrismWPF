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
using Utility.Controls;
using Utility.Model;

namespace PrismWPF.ViewModels
{
    public class ViewClitntViewModel : BaseViewModel
    {
        public DelegateCommand DetailCommand { get; private set; }

        public GridSource<ClientModel> ClientSource { get { if (_ClientSource == null) _ClientSource = new GridSource<ClientModel>(); return _ClientSource; } set { SetProperty(ref _ClientSource, value); } }
        GridSource<ClientModel> _ClientSource;
        public GridSource<ClientContactModel> ClientContactSource { get { if (_ClientContactSource == null) _ClientContactSource = new GridSource<ClientContactModel>(); return _ClientContactSource; } set { SetProperty(ref _ClientContactSource, value); } }
        GridSource<ClientContactModel> _ClientContactSource;

        //public ObservableCollection<ClientModel> ClientList { get { return _ClientList; } set { SetProperty(ref _ClientList, value); } }
        //ObservableCollection<ClientModel> _ClientList;

        //public ClientModel CurrentClient { get { return _CurrentClient; } set { SetProperty(ref _CurrentClient, value); } }
        //ClientModel _CurrentClient;

        public ViewClitntViewModel(IContainerExtension container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;

            DetailCommand = new DelegateCommand(() =>
            {
                //ClientList.Add(new ClientModel { Name = "RRRR", Idno = Guid.NewGuid().ToString() });
                //ClientList.FirstOrDefault().Name = "RRRR";

                //NavigationParameters param = new NavigationParameters() { { "Data", new ClientModel() } };
                //Navigation("ViewAccounting", param);
            });

            ClientSource.OnSelect = (item) =>
            {
                ClientContactSource.ItemsSource = item.ClientContact;
            };
            ClientSource.ItemsSource = new ObservableCollection<ClientModel>
            {
                new ClientModel{ Idno = Guid.NewGuid().ToString() ,Name = "AAAA", Memo = "MEMO", ClientContact = new ObservableCollection<ClientContactModel>
                {
                    new ClientContactModel{ Address="Address", ContactNote="ContactNote", Phone="Phone", PhoneExt="PhoneExt"},
                    new ClientContactModel{ Address="AddressQ", ContactNote="ContactNoteQ", Phone="PhoneQ", PhoneExt=""},
                    new ClientContactModel{ Address="AddressW", ContactNote="ContactNoteW", Phone="PhoneW", PhoneExt=""},
                } },
                new ClientModel{ Idno = Guid.NewGuid().ToString() ,Name = "BBBB", Memo = "MEMWERTO"},
                new ClientModel{ Idno = Guid.NewGuid().ToString() ,Name = "CCC", Memo = "ASDAMEMO", ClientContact = new ObservableCollection<ClientContactModel>
                {
                    new ClientContactModel{ Address="AddressW", ContactNote="ContactNoteW", Phone="PhoneW", PhoneExt=""},
                } },
            };

        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnPropertyChanged(args);
            Debug.WriteLine($"OnPropertyChanged[{this.GetType().Name}] - {args.PropertyName}");
        }
    }
}
