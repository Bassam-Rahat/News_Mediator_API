using News_Mediator_API.Models;
using News_Mediator_API.Pagination;

namespace News_Mediator_API.Interfaces
{
    public interface IBookmarkRepository
    {
        string Delete(int id);
        News Save(int id);
        PaginationDTO<News> Get(int page, float pageSize);
        List<News> GetAll();
        PaginationDTO<News> GetFilterAndSorting(FilterData data);
    }
}
