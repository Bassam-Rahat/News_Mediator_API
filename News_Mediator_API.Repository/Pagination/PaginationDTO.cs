namespace News_Mediator_API.Repository.Pagination
{
    public class PaginationDTO<T>
    {
        public List<T> Items { get; set; } = new List<T>();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
        public int TotalCount { get; set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }
    }
}
