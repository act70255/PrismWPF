using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checo.Repository.Entity
{
    public class TradeDetail: BaseEntity
    {
        public string TradeID { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
        public int Unit { get; set; }
        public decimal Subtotal { get; set; }
        public string ItemID { get; set; }
        public virtual Item Item { get; set; }
    }
}
