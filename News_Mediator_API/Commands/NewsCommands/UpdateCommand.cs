using MediatR;
using News_Mediator_API.Models;

namespace News_Mediator_API.Commands.NewsCommands
{
    public record class UpdateCommand(int id, News updateRequest) : IRequest<News>;
}
