namespace News_Mediator_API.Repository.Users;

using System.ComponentModel.DataAnnotations;

public class UserDataRequest
{
    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }
}
