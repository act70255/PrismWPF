using System;
using System.Collections.Generic;

namespace Checo.Models
{
    public class TradeModel
    {
        public string ID { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string TradeNO { get; set; }
        public string UserID { get; set; }
        public decimal Amount { get; set; }
        public int Unit { get; set; }
        public decimal Subtotal { get; set; }
        public virtual IList<TradeDetailModel> Detail { get; set; }
    }
}
