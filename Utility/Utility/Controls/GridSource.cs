using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Utility.Controls
{
    public class GridSource<T> : BindableBase
    {
        public Action<T> OnSelect;
        private ObservableCollection<T> _ItemsSource = new ObservableCollection<T>();
        public ObservableCollection<T> ItemsSource
        {
            get { return _ItemsSource; }
            set
            {
                SetProperty(ref _ItemsSource, value);
                if (_ItemsSource != null && _ItemsSource.Count > 0 && SelectedItem == null)
                {
                    SelectedItem = _ItemsSource.FirstOrDefault();
                }
            }
        }
        public void SetItemsSource(IEnumerable<T> itemSource)
        {
            ItemsSource = new ObservableCollection<T>(itemSource);
        }
        public T _SelectedItem;
        public T SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                SetProperty(ref _SelectedItem, value);
                if (OnSelect != null && _SelectedItem != null)
                    OnSelect(_SelectedItem);
            }
        }
    }
}
