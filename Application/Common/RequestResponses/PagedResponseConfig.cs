using System;

namespace Application.Common.RequestResponses
{
    public class PagedResponseConfig
    {
        private const int DefaultPage = 1;
        private const int DefaultPageSize = 10;

        public string? Filter { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public PagedResponseConfig()
        {
            Page = DefaultPage;
            Size = DefaultPageSize;
        }
        public PagedResponseConfig(string? filter, int? page = null, int? size = null)
        {
            page ??= page < DefaultPage ? DefaultPage : page;
            size ??= size < DefaultPageSize ? DefaultPageSize : size;

            if (page <= 0)
                throw new ArgumentOutOfRangeException(nameof(page));

            if (size <= 0)
                throw new ArgumentOutOfRangeException(nameof(size));           
        }
    }
}
