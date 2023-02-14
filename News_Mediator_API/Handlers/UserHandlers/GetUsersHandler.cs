using MediatR;
using News_Mediator_API.Interfaces;
using News_Mediator_API.Models;
using News_Mediator_API.Queries.UserQueries;

namespace News_Mediator_API.Handlers.UserHandlers
{
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, List<User>>
    {
        private readonly IRegisterRepository _registerRepository;
        public GetUsersHandler(IRegisterRepository registerRepository)
        {
            _registerRepository = registerRepository;
        }

        public Task<List<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_registerRepository.Get());
        }
    }
}
