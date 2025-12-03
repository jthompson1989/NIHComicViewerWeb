using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NIHComicViewer.Infrastructure.Entities;
using NIHComicViewer.Infrastructure.Repositories.Interface;

namespace NIHComicViewer.Infrastructure.Repositories
{
    public class ComicRepository : IComicRepository
    {
        private readonly NihcomicContext _context;

        public ComicRepository(NihcomicContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Comic>> GetComicsAsync(int pageNumber = 1, int count = 20)
        {
            var skip = Math.Max(0, (pageNumber - 1) * count);
            return await _context.Comics
                .AsNoTracking()
                .Include(c => c.ComicTags).ThenInclude(ct => ct.Tag)
                .Include(c => c.ComicPages)
                .OrderBy(c => c.Name)
                .Skip(skip)
                .Take(count)
                .ToListAsync();
        }

        public async Task<Comic?> GetComicByIdAsync(long id)
        {
            return await _context.Comics
                .AsNoTracking()
                .Include(c => c.ComicTags).ThenInclude(ct => ct.Tag)
                .Include(c => c.ComicPages)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Comic>> GetComicsByAuthorAsync(string author, int pageNumber = 1, int count = 20)
        {
            if (string.IsNullOrWhiteSpace(author)) return new List<Comic>();
            var skip = Math.Max(0, (pageNumber - 1) * count);

            return await _context.Comics
                .AsNoTracking()
                .Where(c => EF.Functions.ILike(c.Author, author))
                .Include(c => c.ComicTags).ThenInclude(ct => ct.Tag)
                .OrderBy(c => c.Name)
                .Skip(skip)
                .Take(count)
                .ToListAsync();
        }

        public async Task<List<Comic>> GetComicsByLanguageAsync(string language, int pageNumber = 1, int count = 20)
        {
            if (string.IsNullOrWhiteSpace(language)) return new List<Comic>();
            var skip = Math.Max(0, (pageNumber - 1) * count);

            return await _context.Comics
                .AsNoTracking()
                .Where(c => c.Language != null && EF.Functions.ILike(c.Language, language))
                .Include(c => c.ComicTags).ThenInclude(ct => ct.Tag)
                .OrderBy(c => c.Name)
                .Skip(skip)
                .Take(count)
                .ToListAsync();
        }

        public async Task<List<Comic>> GetComicsByYearAsync(string year, int pageNumber = 1, int count = 20)
        {
            if (string.IsNullOrWhiteSpace(year)) return new List<Comic>();
            var skip = Math.Max(0, (pageNumber - 1) * count);

            return await _context.Comics
                .AsNoTracking()
                .Where(c => (c.StartYear != null && EF.Functions.ILike(c.StartYear, year))
                         || (c.EndYear != null && EF.Functions.ILike(c.EndYear, year)))
                .Include(c => c.ComicTags).ThenInclude(ct => ct.Tag)
                .OrderBy(c => c.Name)
                .Skip(skip)
                .Take(count)
                .ToListAsync();
        }

        public async Task<List<Comic>> GetComicsByTagsAsync(string[] tags, int pageNumber = 1, int count = 20)
        {
            if (tags == null || tags.Length == 0) return new List<Comic>();
            var cleaned = tags.Select(t => t?.Trim()).Where(t => !string.IsNullOrEmpty(t)).ToArray();
            if (cleaned.Length == 0) return new List<Comic>();
            var skip = Math.Max(0, (pageNumber - 1) * count);

            return await _context.Comics
                .AsNoTracking()
                .Include(c => c.ComicTags).ThenInclude(ct => ct.Tag)
                .Where(c => c.ComicTags.Any(ct => cleaned.Contains(ct.Tag.Name)))
                .OrderBy(c => c.Name)
                .Skip(skip)
                .Take(count)
                .ToListAsync();
        }

        public async Task<bool> AddComicAsync(Comic comic)
        {
            if (comic == null) return false;
            try
            {
                await _context.Comics.AddAsync(comic);
                return await _context.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateComicAsync(Comic comic)
        {
            if (comic == null) return false;
            try
            {
                _context.Comics.Update(comic);
                return await _context.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteComicAsync(long id)
        {
            try
            {
                var entity = await _context.Comics.FindAsync(id);
                if (entity == null) return false;
                _context.Comics.Remove(entity);
                return await _context.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}