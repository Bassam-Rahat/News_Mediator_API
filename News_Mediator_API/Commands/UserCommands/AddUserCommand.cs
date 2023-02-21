using MediatR;
using News_Mediator_API.Entities;
using News_Mediator_API.Repository.Models;

namespace News_Mediator_API.Commands.UserCommands;
public record AddUserCommand : IRequest<UserDTO>
{
    public string Email { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public Role Role { get; set; }
}
