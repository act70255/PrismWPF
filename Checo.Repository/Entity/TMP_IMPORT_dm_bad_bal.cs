using System;
using System.Collections.Generic;
using System.Text;

namespace Checo.Repository.Entity
{
    [System.ComponentModel.DataAnnotations.Schema.Table("TMP_IMPORT_dm_bad_bal")]
    public class TMP_IMPORT_dm_bad_bal
    {
        public string 終結日 { get; set; } = "";
        public string 債券名稱 { get; set; } = "";
        public string 交易序號 { get; set; } = "";
        public Double 持有面額 { get; set; } = 0;
        public Double 買入成本 { get; set; } = 0;
        public Double 折溢價 { get; set; } = 0;
        public Double 累計攤銷 { get; set; } = 0;
        public String 買入日期 { get; set; } = "";
    }
}
