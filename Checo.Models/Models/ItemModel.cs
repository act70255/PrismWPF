using System;
using System.Collections.Generic;

namespace Checo.Models
{
    public class ItemModel
    {
        public string ID { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string Name { get; set; }
        public string SerialNo { get; set; }
        public string BatchNo { get; set; }
        public decimal Price { get; set; }
        public decimal StoredAmount { get; set; }
        public int Unit { get; set; }
    }
}
