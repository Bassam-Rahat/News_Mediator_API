using News_Mediator_API.Domain.Models;
using News_Mediator_API.Repository.Pagination;
using News_Mediator_API.Repository.Users;
using News_Mediator_API.Repository.Models;

namespace News_Mediator_API.Repository.Interfaces
{
    public interface IRegisterRepository
    {
        UserDataResponse Authenticate(UserDataRequest model);
        User Add(User User);
        User GetById(int id);
        List<User> Get();
        string Delete(int id);
        PaginationDTO<User> GetAll(int page, float pageSize);
        PaginationDTO<User> GetFilteringandSorting(FilterData data);
    }
}
