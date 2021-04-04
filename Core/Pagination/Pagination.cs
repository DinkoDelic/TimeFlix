using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Helpers
{
    public class Pagination<T> where T:class
    {
        public Pagination(IReadOnlyList<T> items, int currentPage, int itemCount, int offset)
        {
            CurrentPage = currentPage;
            // returs total amount of pages rounded up.
            TotalPages =(int) Math.Ceiling(itemCount / (decimal) offset);
            Offset = offset;
            ItemCount = itemCount;
            Data = items;
        }

        public int CurrentPage { get; }
        public int TotalPages { get; }
        public int Offset { get; }
        public int ItemCount { get; set; }
        public IReadOnlyList<T> Data { get; set; }
    }
}