using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NIHComicViewer.Infrastructure.Entities;
using NIHComicViewer.Infrastructure.Repositories.Interface;

namespace NIHComicViewer.Infrastructure.Repositories
{
    public class ComicPageRepository : IComicPageRepository
    {
        private readonly NihcomicContext _context;

        public ComicPageRepository(NihcomicContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<ComicPage>> GetComicPagesAsync(long comicId)
        {
            return await _context.ComicPages
                .AsNoTracking()
                .Where(p => p.ComicId == comicId)
                .OrderBy(p => p.PageNumber)
                .ToListAsync();
        }

        public async Task<ComicPage?> GetComicPageByPageNumberAsync(long comicId, int pageNumber)
        {
            return await _context.ComicPages
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.ComicId == comicId && p.PageNumber == pageNumber);
        }

        public async Task<bool> AddComicPageAsync(ComicPage comicPage)
        {
            if (comicPage == null) return false;

            try
            {
                await _context.ComicPages.AddAsync(comicPage);
                return await _context.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateComicPageAsync(ComicPage comicPage)
        {
            if (comicPage == null) return false;

            try
            {
                _context.ComicPages.Update(comicPage);
                return await _context.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteComicPageAsync(long id)
        {
            try
            {
                var entity = await _context.ComicPages.FindAsync(id);
                if (entity == null) return false;

                _context.ComicPages.Remove(entity);
                return await _context.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}