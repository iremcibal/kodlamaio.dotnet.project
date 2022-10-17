using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Paging
{
    public static class IQueryablePaginateExtensions
    {
        public static IPaginate<T> ToPaginate<T>(this IQueryable<T> source, int index = 0, int size = 10, int from = 0)
        {
            return new Paginate<T>(source, index, size, from);
        }
    }
}
