namespace Talabaty.APIs.Helpers
{
    public class Pagination<T>
    {
        public Pagination()
        {
        }

        public Pagination(int pageIndex , int PageSize, IReadOnlyList<T> data)
        {
            PageIndex = pageIndex;
            this.PageSize = PageSize;
            Data = data;
            Count = data.Count;
        }
        public int PageSize { get; set; } = 5;
        public int PageIndex { get; set; } = 1;
        public int Count { get; set; }
        public IReadOnlyList<T> Data { get; set; }

    }
}
