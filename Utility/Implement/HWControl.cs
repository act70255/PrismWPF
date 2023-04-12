using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility.Implement
{
    public class HWControl
    {
        public void SendKey()
        {
            List<StairObj> TestList = new List<StairObj>();
            for (int i = 0; i <= 5; i++)
            {
                var item = new StairObj { Level = 0, Content = Guid.NewGuid().ToString() };
                for (int i1 = 0; i1 <= 7; i1++)
                {
                    var item1 = new StairObj { Level = 1, Content = Guid.NewGuid().ToString() };
                    for (int i2 = 0; i2 <= 9; i2++)
                    {
                        var item2 = new StairObj { Level = 2, Content = Guid.NewGuid().ToString() };
                        item1.List.Add(item2);
                    }
                    item.List.Add(item1);
                }
                TestList.Add(item);
            }

            var parsed = TestList.SelectMany(s => s.List.SelectMany(ss => ss.List)).ToList();
        }
    }
    public class StairObj
    {
        public int Level { get; set; } = 0;
        public string Content { get; set; } = "";
        public List<StairObj> List { get; set; } = new List<StairObj>();
    }
}
