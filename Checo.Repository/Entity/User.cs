using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checo.Repository.Entity
{
    public class User: BaseEntity
    {
        public override string ID { get => base.ID; set => base.ID = value; }
        public string Name { get; set; }
        public string Company { get; set; }
    }
}
