namespace News_Mediator_API.Repository.Repository;

using AutoMapper;
using Microsoft.Extensions.Options;
using News_Mediator_API.Configuration;
using News_Mediator_API.FilteringSorting;
using News_Mediator_API.Repository.Interfaces;
using News_Mediator_API.Domain.Models;
using News_Mediator_API.Domain.Models;
using News_Mediator_API.Repository.Pagination;
using News_Mediator_API.Repository.Users;
using System.Web.Http.Filters;
using News_Mediator_API.Repository.Models;

public class RegisterRepository : IRegisterRepository
{
    //PaginationResult _paginationResult = new PaginationResult();
    //Filtering _filtering = new Filtering();
    //Sorting<User> _sorting = new Sorting<User>();

    private NewsApiContext _context;
    private readonly IMapper _mapper;

    public RegisterRepository(NewsApiContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public User Authenticate(UserDataRequest model)
    {
        var user = _context.Users.SingleOrDefault(x => x.UserName == model.UserName && x.Password == model.Password);

        // validate
        if (user == null)
            return null;

        // authentication successful so generate jwt token
        //var jwtToken = _jwtUtils.GenerateJwtToken(user);

        //return new UserDataResponse(user, jwtToken);

        //var userDataResponse = _mapper.Map<UserDataResponse>(user);
        //userDataResponse.Token = jwtToken;

        return user;
    }

    public User Add(User user)
    {
        //var user = _mapper.Map<User>(newUser);
        _context.Users.Add(user);
        _context.SaveChanges();

        return user;
    }

    public User GetById(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }

    public List<User> Get()
    {
        if (_context.Users is null)
        {
            return null;
        }
        _context.SaveChanges();

        return _context.Users.ToList();
    }

    public string Delete(int id)
    {
        var user = _context.Users.FirstOrDefault(x => x.Id == id);
        var bookmarks = _context.BookMarks.Where(b => b.UserId == id);

        if (user == null)
        {
            return null;
        }

        _context.BookMarks.RemoveRange(bookmarks);
        _context.Users.Remove(user);

        _context.SaveChanges();
        return "User Deleted Successfully!";
    }

    public PaginationDTO<User> GetAll(int page, float pageSize)
    {
        var result = PaginationResult.GetPagination<User>(page, pageSize, _context.Users.AsQueryable());
        return result;
    }

    public PaginationDTO<User> GetFilteringandSorting(FilterData data)
    {
        var query = _context.Users.AsQueryable();
        var filter = Filtering.Filter<User>(data.columnName, data.find, query);
        var sort = Sorting<User>.Sort(data.sortOrder, data.columnName, filter);
        var result = PaginationResult.GetPagination(data.page, data.pageSize, sort);
        _context.SaveChanges();
        return result;
    }
}
