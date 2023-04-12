using Checo.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Checo.Service.Utility
{
    public class UtilityService : IUtilityService
    {
        public UtilityService()
        { }

        public T Map<T>(object source)
        {
            return MapByProperties<T>(source);
        }

        public List<T> MapList<T>(IEnumerable<object> sourceList)
        {
            var result = new List<T>();
            foreach (var item in sourceList)
            {
                result.Add(MapByProperties<T>(item));
            }
            return result;
        }
        T MapByProperties<T>(object source)
        {
            var result = Activator.CreateInstance<T>();
            var sourceType = source.GetType();
            var targetType = typeof(T);
            foreach (var targetProp in targetType.GetProperties())
            {
                if (!targetProp.CanWrite)
                {
                    continue;
                }
                var sourceProp = sourceType
                    .GetProperties()
                    .FirstOrDefault(p => p.Name == targetProp.Name);
                if (sourceProp != null)
                {
                    targetProp.SetValue(result, sourceProp.GetValue(source));
                }
            }
            return result;
        }
    }
}
