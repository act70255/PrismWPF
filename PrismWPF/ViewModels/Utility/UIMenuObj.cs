using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismWPF.ViewModels
{
    public class UIMenuObj : BindableBase
    {
        public UIMenuObj(string description, string url)
        {
            Description = description;
            NavigationUrl = url;
        }

        public bool IsExpand { get { return _IsExpand; } set { SetProperty(ref _IsExpand, value); } }
        bool _IsExpand = false;
        public string Description { get; set; }
        public string NavigationUrl { get; set; }
        public List<UIMenuObj> SubMenu { get; set; } = new List<UIMenuObj>();
    }
}
