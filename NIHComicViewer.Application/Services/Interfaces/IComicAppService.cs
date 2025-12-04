using NIHComicViewer.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIHComicViewer.Application.Services.Interfaces
{
    /// <summary>
    /// Defines application-level operations for managing comics.
    /// </summary>
    /// <remarks>
    /// Implementations provide asynchronous methods to query, add, update, and delete comic data.
    /// </remarks>
    public interface IComicAppService
    {
        /// <summary>
        /// Retrieves a single comic by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the comic to retrieve.</param>
        /// <returns>
        /// A <see cref="Task{ComicModel}"/> that represents the asynchronous operation.
        /// The task result contains the <see cref="ComicModel"/> if found; otherwise, <c>null</c>.
        /// </returns>
        Task<ComicModel?> GetComicByIdAsync(long id);

        /// <summary>
        /// Retrieves a paginated list of comics.
        /// </summary>
        /// <param name="pageNumber">The 1-based page number to retrieve. Defaults to 1.</param>
        /// <param name="count">The number of items per page. Defaults to 20.</param>
        /// <returns>
        /// A <see cref="Task{List{ComicModel}}"/> containing the comics for the requested page.
        /// </returns>
        Task<List<ComicModel>> GetComicsAsync(int pageNumber = 1, int count = 20);

        /// <summary>
        /// Retrieves a paginated list of comics filtered by author.
        /// </summary>
        /// <param name="author">The author name to filter by.</param>
        /// <param name="pageNumber">The 1-based page number to retrieve. Defaults to 1.</param>
        /// <param name="count">The number of items per page. Defaults to 20.</param>
        /// <returns>
        /// A <see cref="Task{List{ComicModel}}"/> containing comics that match the specified author.
        /// </returns>
        Task<List<ComicModel>> GetComicsByAuthorAsync(string author, int pageNumber = 1, int count = 20);

        /// <summary>
        /// Retrieves a paginated list of comics filtered by language.
        /// </summary>
        /// <param name="language">The language code or name to filter by.</param>
        /// <param name="pageNumber">The 1-based page number to retrieve. Defaults to 1.</param>
        /// <param name="count">The number of items per page. Defaults to 20.</param>
        /// <returns>
        /// A <see cref="Task{List{ComicModel}}"/> containing comics that match the specified language.
        /// </returns>
        Task<List<ComicModel>> GetComicsByLanguageAsync(string language, int pageNumber = 1, int count = 20);

        /// <summary>
        /// Retrieves a paginated list of comics filtered by year.
        /// </summary>
        /// <param name="year">The year to filter by (string to allow flexible formats).</param>
        /// <param name="pageNumber">The 1-based page number to retrieve. Defaults to 1.</param>
        /// <param name="count">The number of items per page. Defaults to 20.</param>
        /// <returns>
        /// A <see cref="Task{List{ComicModel}}"/> containing comics that match the specified year.
        /// </returns>
        Task<List<ComicModel>> GetComicsByYearAsync(string year, int pageNumber = 1, int count = 20);

        /// <summary>
        /// Retrieves a paginated list of comics that contain any of the specified tags.
        /// </summary>
        /// <param name="tags">An array of tag values to filter by.</param>
        /// <param name="pageNumber">The 1-based page number to retrieve. Defaults to 1.</param>
        /// <param name="count">The number of items per page. Defaults to 20.</param>
        /// <returns>
        /// A <see cref="Task{List{ComicModel}}"/> containing comics that match one or more of the provided tags.
        /// </returns>
        Task<List<ComicModel>> GetComicsByTagsAsync(string[] tags, int pageNumber = 1, int count = 20);

        /// <summary>
        /// Adds a new comic to the data store.
        /// </summary>
        /// <param name="comicModel">The comic model to add. Must not be <c>null</c>.</param>
        /// <returns>
        /// A <see cref="Task{Boolean}"/> that represents the asynchronous operation.
        /// The task result is <c>true</c> if the comic was added successfully; otherwise <c>false</c>.
        /// </returns>
        Task<bool> AddComicAsync(ComicModel comicModel);

        /// <summary>
        /// Updates an existing comic in the data store.
        /// </summary>
        /// <param name="comicModel">The comic model containing updated data. Must include the identifier of the comic to update.</param>
        /// <returns>
        /// A <see cref="Task{Boolean}"/> that represents the asynchronous operation.
        /// The task result is <c>true</c> if the update succeeded; otherwise <c>false</c>.
        /// </returns>
        Task<bool> UpdateComicAsync(ComicModel comicModel);

        /// <summary>
        /// Deletes a comic by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the comic to delete.</param>
        /// <returns>
        /// A <see cref="Task{Boolean}"/> that represents the asynchronous operation.
        /// The task result is <c>true</c> if the comic was deleted; otherwise <c>false</c> (for example, if not found).
        /// </returns>
        Task<bool> DeleteComicAsync(long id);

    }
}
