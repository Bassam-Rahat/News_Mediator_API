using MediatR;
using News_Mediator_API.Models;

namespace News_Mediator_API.Commands.UserCommands;
public record AddUserCommand(User user) : IRequest<string>;
