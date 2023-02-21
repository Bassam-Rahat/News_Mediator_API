using News_Mediator_API.Domain.Models;

namespace News_Mediator_API.Repository.Interfaces
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(User user);
        public int? ValidateJwtToken(string token);
    }
}
