using System;
using System.Collections.Generic;
using News_Mediator_API.Configuration;

namespace News_Mediator_API.Domain.Models;

public partial class News : TrackableBaseEntity
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public string Content { get; set; } = null!;

    public virtual ICollection<BookMark> BookMarks { get; } = new List<BookMark>();
}
