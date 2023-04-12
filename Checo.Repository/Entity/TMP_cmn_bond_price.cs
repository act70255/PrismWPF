using System;
using System.Collections.Generic;
using System.Text;

namespace Checo.Repository.Entity
{
    [System.ComponentModel.DataAnnotations.Schema.Table("TMP_cmn_bond_price")]
    public class TMP_cmn_bond_price
    {
        public string log_id { get; set; }
        public string log_user { get; set; }
        public DateTime log_time { get; set; }
        public string log_type { get; set; }
        public string data_type { get; set; }
        public DateTime data_dt { get; set; }
        public double source { get; set; }
        public string code { get; set; }
        public DateTime price_dt { get; set; }
        public double price { get; set; }
        public double duration { get; set; }
        public double rate { get; set; }
        //public string lock      {get;set;}
        public string lockuser { get; set; }
        public DateTime locktime { get; set; }
        public string loguser { get; set; }
        public DateTime logtime { get; set; }
    }
}
