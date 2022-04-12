namespace XamarinExamen.Models
{
    public class Pagination
    {
        public int PageIndex { get; set; } = 1;

        private int pageSize = 10;
        private readonly int maxPageSize = 50;

        public int PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
