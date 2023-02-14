using MediatR;
using News_Mediator_API.Interfaces;
using News_Mediator_API.Models;
using News_Mediator_API.Queries.UserQueries;

namespace News_Mediator_API.Handlers.UserHandlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIDQuery, User>
    {
        IRegisterRepository _registerRepository;
        public GetUserByIdHandler(IRegisterRepository registerRepository)
        {
            _registerRepository = registerRepository;
        }

        public Task<User> Handle(GetUserByIDQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_registerRepository.GetById(request.id));
        }
    }
}
