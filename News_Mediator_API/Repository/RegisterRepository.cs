namespace News_Mediator_API.Repository;

using Microsoft.Extensions.Options;
using News_Mediator_API.FilteringSorting;
using News_Mediator_API.Helpers;
using News_Mediator_API.Interfaces;
using News_Mediator_API.Models;
using News_Mediator_API.Pagination;
using News_Mediator_API.Users;
using System.Web.Http.Filters;

public class RegisterRepository : IRegisterRepository
{
    PaginationResult _paginationResult = new PaginationResult();
    Filtering _filtering = new Filtering();
    Sorting<User> _sorting = new Sorting<User>();

    private NewsApiContext _context;
    private IJwtUtils _jwtUtils;
    private readonly AppSettings _appSettings;

    public RegisterRepository(NewsApiContext context, IJwtUtils jwtutils, IOptions<AppSettings> appSettings)
    {
        _context = context;
        _jwtUtils = jwtutils;
        _appSettings = appSettings.Value;
    }

    public UserDataResponse Authenticate(UserDataRequest model)
    {
        var user = _context.Users.SingleOrDefault(x => x.UserName == model.UserName && x.Password == model.Password);

        // validate
        if (user == null)
            throw new AppException("Username or password is incorrect");

        // authentication successful so generate jwt token
        var jwtToken = _jwtUtils.GenerateJwtToken(user);

        return new UserDataResponse(user, jwtToken);
    }

    public string Add(User User)
    {
        _context.Users.Add(User);
        _context.SaveChanges();

        return ("Added Successfully!");
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
        return (_context.Users.ToList());
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
        return ("User Deleted Successfully!");
    }

    public PaginationDTO<User> GetAll(int page, float pageSize)
    {
        var result = _paginationResult.GetPagination<User>(page, pageSize, _context.Users.AsQueryable());
        return result;
    }

    public PaginationDTO<User> GetFilteringandSorting(FilterData data)
    {
        var query = _context.Users.AsQueryable();
        var filter = _filtering.Filter<User>(data.columnName, data.find, query);
        var sort = _sorting.Sort(data.sortOrder, data.columnName, filter);
        var result = _paginationResult.GetPagination(data.page, data.pageSize, sort);
        _context.SaveChanges();
        return result;
    }
}
