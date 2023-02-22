using System;
using System.Collections.Generic;
using News_Mediator_API.Configuration;

namespace News_Mediator_API.Domain.Models;

public partial class BookMark : TrackableBaseEntity
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int NewsId { get; set; }

    public virtual News News { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
