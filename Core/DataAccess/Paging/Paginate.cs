using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Paging
{
    public class Paginate<T> : IPaginate<T>
    {
        public int From { get; }
        public int Index { get; }
        public int Size { get; }
        public int Count { get; }
        public int Pages { get; }
        public IList<T> Items { get; }
        public bool HasPrevious
        {
            get
            {
                return Index - From > 0;
            }
        }
        public bool HasNext => Index - From + 1 < Pages;

   
        public Paginate(IEnumerable<T> source, int index, int size, int from)
        {
            if (from > index)
                throw new ArgumentException($"indexFrom: {from} > pageIndex: {index}, must indexFrom <= pageIndex");

            Index = index;
            Size = size;
            From = from;
            if (source is IQueryable<T> queryable)
            {
                Count = queryable.Count();
                Items = queryable.Skip((Index - From) * Size).Take(Size).ToList();
            }
            else
            {
                T[] enumerable = source as T[] ?? source.ToArray();
                Count = enumerable.Count();
                Items = enumerable.Skip((Index - From) * Size).Take(Size).ToList();
            }
           
            Pages = Convert.ToInt32(Math.Ceiling(Count / Convert.ToDouble(Size)));
        }

        public Paginate()
        {
            Items = Array.Empty<T>();
        }
    }
}
