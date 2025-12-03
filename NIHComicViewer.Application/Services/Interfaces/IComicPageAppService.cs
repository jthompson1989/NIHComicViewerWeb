using NIHComicViewer.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIHComicViewer.Application.Services.Interfaces
{
    /// <summary>
    /// Provides application-level operations for managing comic pages.
    /// Implementations coordinate retrieval, creation, update, and deletion of comic page data.
    /// </summary>
    public interface IComicPageAppService
    {
        /// <summary>
        /// Retrieves all pages for the specified comic.
        /// </summary>
        /// <param name="comicId">The identifier of the comic whose pages should be retrieved.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result contains a list of
        /// <see cref="ComicPageModel"/> instances for the specified comic. The list will be empty
        /// if no pages exist for the comic.
        /// </returns>
        Task<List<ComicPageModel>> GetComicPagesAsync(long comicId);

        /// <summary>
        /// Retrieves a single comic page by its page number within the specified comic.
        /// </summary>
        /// <param name="comicId">The identifier of the comic containing the page.</param>
        /// <param name="pageNumber">The 1-based page number to retrieve.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result is the matching
        /// <see cref="ComicPageModel"/> if found; otherwise <c>null</c>.
        /// </returns>
        Task<ComicPageModel?> GetComicPageByPageNumberAsync(long comicId, int pageNumber);

        /// <summary>
        /// Adds a new comic page.
        /// </summary>
        /// <param name="comicPageModel">The model describing the comic page to add.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result is <c>true</c> if the
        /// page was added successfully; otherwise <c>false</c>.
        /// </returns>
        Task<bool> AddComicPageAsync(ComicPageModel comicPageModel);

        /// <summary>
        /// Updates an existing comic page.
        /// </summary>
        /// <param name="comicPageModel">The model containing updated data for the comic page.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result is <c>true</c> if the
        /// update succeeded; otherwise <c>false</c>.
        /// </returns>
        Task<bool> UpdateComicPageAsync(ComicPageModel comicPageModel);

        /// <summary>
        /// Deletes a comic page by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the comic page to delete.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result is <c>true</c> if the
        /// page was deleted successfully; otherwise <c>false</c>.
        /// </returns>
        Task<bool> DeleteComicPageAsync(long id);
    }
}
