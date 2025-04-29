using System;
using System.Collections.Generic;

namespace NIHComicViewer.Infrastructure.Entities;

public partial class ComicPageTag
{
    public long Id { get; set; }

    public long TagId { get; set; }

    public long ComicPageId { get; set; }

    public virtual ComicPage ComicPage { get; set; } = null!;

    public virtual Tag Tag { get; set; } = null!;
}
