using AutoMapper;
using MediatR;
using News_Mediator_API.Authorization;
using News_Mediator_API.Commands.UserCommands;
using News_Mediator_API.Domain.Models;
using News_Mediator_API.Helpers;
using News_Mediator_API.Repository.Interfaces;
using News_Mediator_API.Repository.Users;

namespace News_Mediator_API.Handlers.UserHandlers
{
    public class LoginUserHandler : IRequestHandler<LoginUserCoommand, UserDataResponse>
    {
        private readonly IRegisterRepository _registerRepository;
        private readonly IMapper _mapper;
        private readonly IJwtUtils _jwtUtils;
        public LoginUserHandler(IRegisterRepository registerRepository, IMapper mapper, IJwtUtils jwtutils)
        {
            _registerRepository = registerRepository;
            _mapper = mapper;
            _jwtUtils = jwtutils;
        }

        public Task<UserDataResponse> Handle(LoginUserCoommand request, CancellationToken cancellationToken)
        {
            var user = _registerRepository.Authenticate(request.model);

            if (user == null)
                throw new AppException("Username or password is incorrect");

            var jwtToken = _jwtUtils.GenerateJwtToken(user);

            var userDataResponse = _mapper.Map<UserDataResponse>(user);
            userDataResponse.Token = jwtToken;

            return Task.FromResult(userDataResponse);
        }
    }
}
