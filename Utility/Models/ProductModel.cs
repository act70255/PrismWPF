using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Utility.Model
{
    public class ProductModel : BindableBase
    {
        public string ID { get { return _ID; } set { SetProperty(ref _ID, value); } }
        private string _ID;
        public string Name { get { return _Name; } set { SetProperty(ref _Name, value); } }
        private string _Name;
        public string Unit { get { return _Unit; } set { SetProperty(ref _Unit, value); } }
        private string _Unit;
        public ObservableCollection<ProductDetailModel> Details { get { return _Details; } set { SetProperty(ref _Details, value); } }
        private ObservableCollection<ProductDetailModel> _Details = new ObservableCollection<ProductDetailModel>();
    }
    public class ProductDetailModel : BindableBase
    {
        public ProductDetailModel ProductMaster { get { return _ProductMaster; } set { SetProperty(ref _ProductMaster, value); } }
        private ProductDetailModel _ProductMaster;
        public string ID { get { return _ID; } set { SetProperty(ref _ID, value); } }
        private string _ID;
        public string MasterID { get { return _MasterID; } set { SetProperty(ref _MasterID, value); } }
        private string _MasterID;
        public string ItemNO { get { return _ItemNO; } set { SetProperty(ref _ItemNO, value); } }
        private string _ItemNO;
        public string BatchNO { get { return _BatchNO; } set { SetProperty(ref _BatchNO, value); } }
        private string _BatchNO;
        /// <summary>
        /// 庫存
        /// </summary>
        public double Quantity { get { return _Quantity; } set { SetProperty(ref _Quantity, value); } }
        private double _Quantity;
        /// <summary>
        /// 計量單位
        /// </summary>
        public string Unit { get { return _Unit; } set { SetProperty(ref _Unit, value); } }
        private string _Unit;
    }
}
