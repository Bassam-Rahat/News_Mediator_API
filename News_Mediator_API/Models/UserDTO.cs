using News_Mediator_API.Enums;

namespace News_Mediator_API.Repository.Models
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string Email { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public Role Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
