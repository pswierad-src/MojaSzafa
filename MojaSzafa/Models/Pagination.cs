using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MojaSzafa.Models
{
    /// <summary>
    /// Helper class for creating paginated list. Based of List<T> class.
    /// </summary>
    /// <typeparam name="T">Type of item in list</typeparam>
    public class Pagination<T> : List<T>
    {
        public int _pageIndex { get; set; }
        public int _amountOfPages { get; set; }
        public Clothing _modelItem { get; set; }

        public Pagination(List<T> list, int amount, int pageIndex, int pageSize)
        {
            _pageIndex = pageIndex;
            _amountOfPages = (int)Math.Ceiling(amount / (double)pageSize);
            _modelItem = new Clothing();
            this.AddRange(list);
        }

        public bool HasPreviousPage
        {
            get
            {
                return (_pageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (_pageIndex < _amountOfPages);
            }
        }

        public static Pagination<T> Create(IQueryable<T> src, int pageIndex, int pageSize)
        {
            var count = src.Count();
            var items = src.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new Pagination<T>(items, count, pageIndex, pageSize);
        }
    }
}
