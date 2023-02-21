using News_Mediator_API.Repository.Interfaces;
using News_Mediator_API.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace News_Mediator_API.Repository.Repository
{
    public class IdentityService : IIdentityService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public IdentityService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }
        public int? GetUserId()
        {
            return GetUser()?.Id;
        }

        private User? GetUser()
        {
            return (User?)_httpContextAccessor.HttpContext?.Items.FirstOrDefault(item => item.Key.Equals("User")).Value;
        }
    }
}
