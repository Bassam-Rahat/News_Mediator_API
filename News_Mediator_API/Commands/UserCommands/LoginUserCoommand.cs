using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using News_Mediator_API.Repository.Users;

namespace News_Mediator_API.Commands.UserCommands;

public record LoginUserCoommand(UserDataRequest model) : IRequest<UserDataResponse>;
