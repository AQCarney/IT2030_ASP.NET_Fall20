using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuarterlySales.Models
{
    public static class IQueryableExtensionMethods
    {
        public static IQueryable<T> PageBy<T>(this IQueryable<T> query,
            int pageNumber, int pageSize)
        {
            return query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }
    }
}
