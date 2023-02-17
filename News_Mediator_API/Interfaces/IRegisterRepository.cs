using News_Mediator_API.Models;
using News_Mediator_API.Pagination;
using News_Mediator_API.Users;

namespace News_Mediator_API.Interfaces
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
