using AutoMapper;
using MediatR;
using News_Mediator_API.Interfaces;
using News_Mediator_API.Models;
using News_Mediator_API.Pagination;
using News_Mediator_API.Queries.UserQueries;

namespace News_Mediator_API.Handlers.UserHandlers
{
    public class GetPaginatedHandler : IRequestHandler<GetPaginatedQuery, PaginationDTO<UserDTO>>
    {
        private readonly IRegisterRepository registerRepository;
        private readonly IMapper _mapper;

        public GetPaginatedHandler(IRegisterRepository registerRepository, IMapper mapper)
        {
            this.registerRepository = registerRepository;
            _mapper = mapper;
        }

        public Task<PaginationDTO<UserDTO>> Handle(GetPaginatedQuery request, CancellationToken cancellationToken)
        {
            var users = registerRepository.GetAll(request.page, request.pageSize);
            var userDTOs = _mapper.Map<PaginationDTO<UserDTO>>(users);

            //var paginationDto = new PaginationDTO<UserDTO>()
            //{
            //    Items = userDTOs
            //};

            return Task.FromResult(userDTOs);
        }
    }
}
