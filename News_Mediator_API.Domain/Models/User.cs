using News_Mediator_API.Configuration;
using News_Mediator_API.Enums;
using System;
using System.Collections.Generic;

namespace News_Mediator_API.Domain.Models;

public partial class User : TrackableBaseEntity
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public Role Role { get; set; }

    public virtual ICollection<BookMark> BookMarks { get; } = new List<BookMark>();
}
