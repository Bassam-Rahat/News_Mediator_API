using MediatR;
using News_Mediator_API.Models;

namespace News_Mediator_API.Commands.NewsCommands
{
    public record class UpdateCommand: IRequest<NewsDTO>
    {
        public int id { get; set; }
        public string Title { get; set; } = null!;

        public string Author { get; set; } = null!;

        public string Content { get; set; } = null!;
    }
}
