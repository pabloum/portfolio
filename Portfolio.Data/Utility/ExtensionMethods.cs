using Portfolio.Entities.Base;
using System.Collections.Generic;

namespace Portfolio.Data.Utility
{
    public static class ExtensionMethods
    {
        public static void ReplaceWith<T>(this List<T> list, T oldObj, T newObj) where T : EntityBase
        {
            var i = list.IndexOf(oldObj);
            list[i] = newObj;
        }
        
    }
}
