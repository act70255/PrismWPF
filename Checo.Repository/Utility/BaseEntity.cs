using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checo.Repository.Entity
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            ID = Guid.NewGuid().ToString();
            CreateTime = DateTime.Now;
        }

        public virtual string ID { get; set; }
        public virtual DateTime CreateTime { get; set; }
        public virtual DateTime? UpdateTime { get; set; }
    }
}
