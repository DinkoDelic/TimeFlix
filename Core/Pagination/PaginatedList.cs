using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Helpers
{
    public class PaginatedList<T> : List<T>
    {
        public PaginatedList(IEnumerable<T> items, int currentPage, int itemCount, int offset)
        {
            CurrentPage = currentPage;
            // returs total amount of pages rounded up.
            TotalPages =(int) Math.Ceiling(itemCount / (decimal) offset);
            ItemCount = itemCount;
            Offset = offset;
            AddRange(items);
        }

        public int CurrentPage { get; }
        public int TotalPages { get; }
        public int ItemCount { get; }
        public int Offset { get; }
    }
}