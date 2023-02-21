using News_Mediator_API.Repository.Models;
using News_Mediator_API.Repository.Pagination;
using News_Mediator_API.Domain.Models;

namespace News_Mediator_API.Repository.Interfaces
{
    public interface INewsRepository
    {
        PaginationDTO<News> Get(int page, float pageSize);
        PaginationDTO<News> GetFilterAndSorting(FilterData data);
        List<News> GetAll();
        News GetById(int id);
        News Add(News news);
        News Update(int id, News updateRequest);
        string Delete(int id);
    }
}
