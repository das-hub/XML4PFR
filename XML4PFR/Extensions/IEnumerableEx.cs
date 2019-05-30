using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML4PFR.Extensions
{
    public static class IEnumerableEx
    {
        public static void Do<T>(this IEnumerable<T> collection, Action<T> action)
        {
            if (collection == null)
                return;

            foreach (T item in collection) action(item);
        }
    }
}
