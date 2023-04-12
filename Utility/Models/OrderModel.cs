using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Model
{
    public class OrderModel : BindableBase
    {
        public DateTime OrderDate { get { return _OrderDate; } set { SetProperty(ref _OrderDate, value); } }
        private DateTime _OrderDate;
        public string ProductID { get { return _ProductID; } set { SetProperty(ref _ProductID, value); } }
        private string _ProductID;
        public string ProductName { get { return _ProductName; } set { SetProperty(ref _ProductName, value); } }
        private string _ProductName;
        public string ProductItemNO { get { return _ProductItemNO; } set { SetProperty(ref _ProductItemNO, value); } }
        private string _ProductItemNO;
        public string ProductBatchNO { get { return _ProductBatchNO; } set { SetProperty(ref _ProductBatchNO, value); } }
        private string _ProductBatchNO;
        public double Quantity { get { return _Quantity; } set { SetProperty(ref _Quantity, value); } }
        private double _Quantity;
        public string Unit { get { return _Unit; } set { SetProperty(ref _Unit, value); } }
        private string _Unit;
        public decimal Price { get { return _Price; } set { SetProperty(ref _Price, value); } }
        private decimal _Price;
    }
}
