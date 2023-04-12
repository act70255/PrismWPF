using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checo.Repository.Entity
{
    public class Trade : BaseEntity
    {
        public override string ID { get => base.ID; set => base.ID = value; }
        //[Comment("")]
        public string TradeNO { get; set; }
        public string UserID { get; set; }
        public decimal Amount { get; set; }
        public int Unit { get; set; }
        public decimal Subtotal { get; set; }
        public virtual IList<TradeDetail> Detail { get; set; }
    }
}
