using System;
using System.Collections.Generic;

namespace Exchange.Domain.Common.Response
{
    public class PagedList<T>
    {
        public List<T> Results { get; }
        public int PageIndex { get; }
        public int TotalPages { get; }
        public int TotalCount { get; }
        
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;
        
        public PagedList(List<T> results, int pageIndex, int pageSize, int totalCount)
        {
            Results = results;
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            TotalCount = totalCount;
        }
    }
}