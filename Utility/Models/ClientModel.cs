using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace Utility.Model
{
    public class ClientModel: BindableBase
    {
        public string Name { get { return _Name; } set { SetProperty(ref _Name, value); } }
        private string _Name;
        public string Idno { get { return _Idno; } set { SetProperty(ref _Idno, value); } }
        private string _Idno;
        public string Memo { get { return _Memo; } set { SetProperty(ref _Memo, value); } }
        private string _Memo;
        public int BASE { get { return _BASE; } set { SetProperty(ref _BASE, value); } }
        private int _BASE;
        public int EXT { get { return _EXT; } set { SetProperty(ref _EXT, value); } }
        private int _EXT;
        public int RES { get { return _RES; } set { SetProperty(ref _RES, value); } }
        private int _RES;

        public ObservableCollection<ClientContactModel> ClientContact { get { return _ClientContact; } set { SetProperty(ref _ClientContact, value); } }
        private ObservableCollection<ClientContactModel> _ClientContact;

        protected override void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnPropertyChanged(args);
            if (args.PropertyName == nameof(BASE) || args.PropertyName == nameof(EXT))
            {
                Debug.WriteLine(BASE);
                RES = BASE * EXT;
            }
        }
    }
    public class ClientContactModel : BindableBase
    {
        public string Address { get { return _Address; } set { SetProperty(ref _Address, value); } }
        private string _Address;
        public string Phone { get { return _Phone; } set { SetProperty(ref _Phone, value); } }
        private string _Phone;
        public string PhoneExt { get { return _PhoneExt; } set { SetProperty(ref _PhoneExt, value); } }
        private string _PhoneExt;
        public string ContactNote { get { return _ContactNote; } set { SetProperty(ref _ContactNote, value); } }
        private string _ContactNote;
    }
}
