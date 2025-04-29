using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NIHComicViewer.Infrastructure.Entities;

namespace NIHComicViewer.Infrastructure.Repositories
{
    public interface IComicPageRepository
    {
        Task<List<ComicPage>> GetComicPagesAsync(long comicId);
        Task<ComicPage?> GetComicPageByPageNumberAsync(long comicId, int pageNumber);
        Task<bool> AddComicPageAsync(ComicPage comicPage);
        Task<bool> UpdateComicPageAsync(ComicPage comicPage);
        Task<bool> DeleteComicPageAsync(long id);
    }
}
