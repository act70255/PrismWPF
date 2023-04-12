using System;
using System.Collections.Generic;

namespace Checo.Models
{
    public class UserModel
    {
        public string ID { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
    }
}
