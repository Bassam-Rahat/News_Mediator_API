using News_Mediator_API.Models;
using News_Mediator_API.Pagination;

namespace News_Mediator_API.Interfaces
{
    public interface INewsRepository
    {
        PaginationDTO<News> Get(int page, float pageSize);
        PaginationDTO<News> GetFilterAndSorting(FilterData data);
        List<News> GetAll();
        News GetById(int id);
        string Add(News news);
        News Update(int id, News updateRequest);
        string Delete(int id);
    }
}
