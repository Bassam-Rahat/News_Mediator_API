using MediatR;
using News_Mediator_API.Commands.UserCommands;
using News_Mediator_API.Interfaces;
using News_Mediator_API.Users;

namespace News_Mediator_API.Handlers.UserHandlers
{
    public class LoginUserHandler : IRequestHandler<LoginUserCoommand, UserDataResponse>
    {
        private readonly IRegisterRepository _registerRepository;
        public LoginUserHandler(IRegisterRepository registerRepository)
        {
            _registerRepository = registerRepository;
        }

        public Task<UserDataResponse> Handle(LoginUserCoommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_registerRepository.Authenticate(request.model));
        }
    }
}
