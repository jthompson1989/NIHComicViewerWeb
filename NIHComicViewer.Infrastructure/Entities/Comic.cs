using System;
using System.Collections.Generic;

namespace NIHComicViewer.Infrastructure.Entities;

public partial class Comic
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Author { get; set; } = null!;

    public string? StartYear { get; set; }

    public string? EndYear { get; set; }

    public string? Language { get; set; }

    public string? Cover { get; set; }

    public DateTime? CreatedDate { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public long? ModifiedBy { get; set; }

    public virtual ICollection<ComicPage> ComicPages { get; set; } = new List<ComicPage>();

    public virtual ICollection<ComicTag> ComicTags { get; set; } = new List<ComicTag>();

    public virtual User? CreatedByNavigation { get; set; }

    public virtual User? ModifiedByNavigation { get; set; }
}
