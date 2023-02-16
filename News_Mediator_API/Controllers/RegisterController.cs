namespace News_Mediator_API.Controllers;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using News_Mediator_API.Authorization;
using News_Mediator_API.Commands.UserCommands;
using News_Mediator_API.Entities;
using News_Mediator_API.Models;
using News_Mediator_API.Pagination;
using News_Mediator_API.Queries.UserQueries;
using News_Mediator_API.Users;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediatR;

    public UsersController(IMediator mediator)
    {
        _mediatR = mediator;
    }

    [AllowAnonymous]
    [HttpPost("Register")]
    public async Task<ActionResult<UserDTO>> Add(AddUserCommand user)
    {
        var result = await _mediatR.Send(user);
        return Ok(result);
    }

    [AllowAnonymous]
    [HttpPost("Login")]
    public async Task<IActionResult> Authenticate(UserDataRequest model)
    {
        var response = await _mediatR.Send(new LoginUserCoommand(model));
        //var response = _userService.Authenticate(model);
        //var result = response as UserDataResponse;
        //return Ok(new
        //{
        //    response.Id,
        //    response.UserName,
        //    response.Email,
        //    response.Password,
        //    response.Role,
        //    response.Token
        //});
        return Ok(response);
    }

    [Authorize(Role.Admin)]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        // only admins can access other user records
        //var currentUser = (User)HttpContext.Items["User"];
        //if (id != currentUser.Id && currentUser.Role != Role.Admin)
        //    return Unauthorized(new { message = "Unauthorized" });

        var user = await _mediatR.Send(new GetUserByIDQuery(id));

        if(user == null)
        {
            return NotFound("No User with such ID Found!");
        }
        return Ok(user);
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<List<UserDTO>>> Get()
    {
        var result = await _mediatR.Send(new GetUsersQuery());

        if (result is null)
        {
            return NotFound("No User Found");
        }
        return Ok(result);
    }

    [Authorize(Role.Admin, Role.User)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<string>> Delete(int id)
    {
        var result = await _mediatR.Send(new DeleteUserCommand(id));    

        if (result is null)
        {
            return NotFound("No User Found");
        }
        return Ok(result);
    }

    [Authorize(Role.Admin, Role.User)]
    [HttpGet("Paginated")]
    public async Task<ActionResult<PaginationDTO<UserDTO>>> GetAll(int page, float pageSize)
    {
        var users = await _mediatR.Send(new GetPaginatedQuery(page, pageSize));
        return Ok(users);
    }

    [Authorize(Role.Admin, Role.User)]
    [HttpGet("Filter")]
    public async Task<ActionResult<PaginationDTO<UserDTO>>> GetFilteringandSorting([FromQuery] FilterData data)
    {
        var users = await _mediatR.Send(new GetFilteringSortingQuery(data));
        return Ok(users);
    }
}
