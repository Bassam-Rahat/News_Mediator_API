using MediatR;
using News_Mediator_API.Interfaces;
using News_Mediator_API.Models;
using News_Mediator_API.Pagination;
using News_Mediator_API.Queries.UserQueries;

namespace News_Mediator_API.Handlers.UserHandlers
{
    public class GetPaginatedHandler : IRequestHandler<GetPaginatedQuery, PaginationDTO<User>>
    {
        private readonly IRegisterRepository registerRepository;

        public GetPaginatedHandler(IRegisterRepository registerRepository)
        {
            this.registerRepository = registerRepository;
        }

        public Task<PaginationDTO<User>> Handle(GetPaginatedQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(registerRepository.GetAll(request.page));
        }
    }
}
