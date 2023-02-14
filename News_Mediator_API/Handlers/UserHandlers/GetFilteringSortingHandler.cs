using MediatR;
using News_Mediator_API.Interfaces;
using News_Mediator_API.Models;
using News_Mediator_API.Pagination;
using News_Mediator_API.Queries.UserQueries;

namespace News_Mediator_API.Handlers.UserHandlers
{
    public class GetFilteringSortingHandler : IRequestHandler<GetFilteringSortingQuery, PaginationDTO<User>>
    {
        private readonly IRegisterRepository registerRepository;

        public GetFilteringSortingHandler(IRegisterRepository registerRepository)
        {
            this.registerRepository = registerRepository;
        }

        public Task<PaginationDTO<User>> Handle(GetFilteringSortingQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(registerRepository.GetFilteringandSorting(request.page, request.columnName, request.find, request.sortOrder));
        }
    }
}
