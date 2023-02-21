using MediatR;
using News_Mediator_API.Repository.Models;

namespace News_Mediator_API.Queries.BookmarkQueries
{
    public record class GetQuery() : IRequest<List<NewsDTO>>;

}
