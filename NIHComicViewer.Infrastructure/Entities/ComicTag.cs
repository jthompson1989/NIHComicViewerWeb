using System;
using System.Collections.Generic;

namespace NIHComicViewer.Infrastructure.Entities;

public partial class ComicTag
{
    public long Id { get; set; }

    public long TagId { get; set; }

    public long ComicId { get; set; }

    public virtual Comic Comic { get; set; } = null!;

    public virtual Tag Tag { get; set; } = null!;
}
