namespace Application.Common.RequestResponses
{
    public class PagedResponse<T> : RequestResponse<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public PagedResponse(T container, int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Container = container;
            this.Message = null;
            this.Succeded = true;
            this.Errors = null;
        }
    }
}
