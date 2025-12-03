using NIHComicViewer.Application.Models;
using NIHComicViewer.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIHComicViewer.Application.Services
{
    public class ComicPageAppService : IComicPageAppService
    {
        public async Task<bool> AddComicPageAsync(ComicPageModel comicPageModel)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteComicPageAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<ComicPageModel?> GetComicPageByPageNumberAsync(long comicId, int pageNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ComicPageModel>> GetComicPagesAsync(long comicId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateComicPageAsync(ComicPageModel comicPageModel)
        {
            throw new NotImplementedException();
        }
    }
}
