using System;
using System.Collections.Generic;
using System.Text;

namespace Checo.Service.Interface
{
    public interface IUtilityService
    {
        T Map<T>(object source);
        List<T> MapList<T>(IEnumerable<object> sourceList);
    }
}
