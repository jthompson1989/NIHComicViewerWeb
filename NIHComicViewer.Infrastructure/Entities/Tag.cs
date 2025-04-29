using System;
using System.Collections.Generic;

namespace NIHComicViewer.Infrastructure.Entities;

public partial class Tag
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ComicPageTag> ComicPageTags { get; set; } = new List<ComicPageTag>();

    public virtual ICollection<ComicTag> ComicTags { get; set; } = new List<ComicTag>();
}
