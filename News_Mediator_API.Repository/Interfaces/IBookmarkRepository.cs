using News_Mediator_API.Domain.Models;
using News_Mediator_API.Repository.Models;
using News_Mediator_API.Repository.Pagination;

namespace News_Mediator_API.Repository.Interfaces
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
