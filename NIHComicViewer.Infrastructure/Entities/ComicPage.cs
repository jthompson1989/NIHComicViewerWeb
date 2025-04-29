using System;
using System.Collections.Generic;

namespace NIHComicViewer.Infrastructure.Entities;

public partial class ComicPage
{
    public long Id { get; set; }

    public long ComicId { get; set; }

    public int PageNumber { get; set; }

    public DateOnly? Date { get; set; }

    public DateTime? CreatedDate { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public long? ModifiedBy { get; set; }

    public virtual Comic Comic { get; set; } = null!;

    public virtual ICollection<ComicPageTag> ComicPageTags { get; set; } = new List<ComicPageTag>();

    public virtual User? CreatedByNavigation { get; set; }

    public virtual User? ModifiedByNavigation { get; set; }
}
