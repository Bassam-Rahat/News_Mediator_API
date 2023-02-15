namespace News_Mediator_API.Pagination
{
    public static class PaginationResult
    {
        public static PaginationDTO<T> GetPagination<T>(int page, float pageSize, IQueryable<T> items)
        {
            var pageResults = pageSize;
            var pageCount = Math.Ceiling(items.Count() / pageResults);
            var totalCount = items.Count();
            bool hasPrevious = page > 1;
            bool hasNext = page < pageCount;

            items = items
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults);
            var findItems = items.ToList();
            //.ToList();

            var paginationResponse = new PaginationDTO<T>
            {
                Items = findItems,
                CurrentPage = page,
                Pages = (int)pageCount,
                TotalCount= totalCount,
                HasPrevious= hasPrevious,
                HasNext= hasNext
            };

            return paginationResponse;
        }
    }
}
