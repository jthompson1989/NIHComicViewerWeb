using System;
using System.Collections.Generic;

namespace NIHComicViewer.Infrastructure.Entities;

public partial class User
{
    public long Id { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? ResetToken { get; set; }

    public DateTime LastSignIn { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsAdmin { get; set; }

    public string EmailAddress { get; set; } = null!;

    public virtual ICollection<Comic> ComicCreatedByNavigations { get; set; } = new List<Comic>();

    public virtual ICollection<Comic> ComicModifiedByNavigations { get; set; } = new List<Comic>();

    public virtual ICollection<ComicPage> ComicPageCreatedByNavigations { get; set; } = new List<ComicPage>();

    public virtual ICollection<ComicPage> ComicPageModifiedByNavigations { get; set; } = new List<ComicPage>();
}
