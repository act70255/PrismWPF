using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checo.Repository.Entity
{
    public class Item : BaseEntity
    {
        public override string ID { get => base.ID; set => base.ID = value; }
        public string Name { get; set; }
        public string SerialNo { get; set; }
        public string BatchNo { get; set; }
        public decimal Price { get; set; }
        public decimal StoredAmount { get; set; }
        public int Unit { get; set; }
    }
}
