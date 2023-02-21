using AutoMapper;
using MediatR;
using News_Mediator_API.Repository.Interfaces;
using News_Mediator_API.Repository.Models;
using News_Mediator_API.Repository.Pagination;
using News_Mediator_API.Queries.UserQueries;

namespace News_Mediator_API.Handlers.UserHandlers
{
    public class GetFilteringSortingHandler : IRequestHandler<GetFilteringSortingQuery, PaginationDTO<UserDTO>>
    {
        private readonly IRegisterRepository registerRepository;
        private readonly IMapper _mapper;

        public GetFilteringSortingHandler(IRegisterRepository registerRepository, IMapper mapper)
        {
            this.registerRepository = registerRepository;
            _mapper = mapper;
        }

        public Task<PaginationDTO<UserDTO>> Handle(GetFilteringSortingQuery request, CancellationToken cancellationToken)
        {
            var users = registerRepository.GetFilteringandSorting(request.data);
            var userDTOs = _mapper.Map<PaginationDTO<UserDTO>>(users);

            return Task.FromResult(userDTOs);
        }
    }
}
