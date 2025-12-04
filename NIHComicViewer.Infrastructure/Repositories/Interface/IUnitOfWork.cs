using System;
using System.Collections.Generic;
using System.Text;

namespace NIHComicViewer.Infrastructure.Repositories.Interface
{
    public interface IUnitOfWork
    {
        IComicRepository ComicRepository { get; }

        IComicPageRepository ComicPageRepository { get; }
        ITagRepository TagRepository { get; }

        IUserRepository UserRepository { get; }

        /// <summary>
        /// Commits changes to the data storage.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the number of state entries written to the database.</returns>
        Task<int> SaveChangesAsync();
    }
}
