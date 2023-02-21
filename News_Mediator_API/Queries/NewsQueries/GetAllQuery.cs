using MediatR;
using News_Mediator_API.Repository.Models;

namespace News_Mediator_API.Queries.NewsQueries
{
    public record class GetAllQuery() : IRequest<List<NewsDTO>>;
}
