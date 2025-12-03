using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NIHComicViewer.Infrastructure.Entities;
using NIHComicViewer.Infrastructure.Repositories.Interface;

namespace NIHComicViewer.Infrastructure.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly NihcomicContext _context;

        public TagRepository(NihcomicContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<string>> GetTagsAsync()
        {
            return await _context.Tags
                .AsNoTracking()
                .OrderBy(t => t.Name)
                .Select(t => t.Name)
                .ToListAsync();
        }

        public async Task<bool> AddTagAsync(string tag)
        {
            if (string.IsNullOrWhiteSpace(tag)) return false;
            if (await _context.Tags.AnyAsync(t => EF.Functions.ILike(t.Name, tag))) return false;

            try
            {
                await _context.Tags.AddAsync(new Tag { Name = tag.Trim() });
                return await _context.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateTagAsync(string oldTag, string newTag)
        {
            if (string.IsNullOrWhiteSpace(oldTag) || string.IsNullOrWhiteSpace(newTag)) return false;

            var existing = await _context.Tags.FirstOrDefaultAsync(t => EF.Functions.ILike(t.Name, oldTag));
            if (existing == null) return false;

            try
            {
                existing.Name = newTag.Trim();
                _context.Tags.Update(existing);
                return await _context.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteTagAsync(string tag)
        {
            if (string.IsNullOrWhiteSpace(tag)) return false;

            var existing = await _context.Tags.FirstOrDefaultAsync(t => EF.Functions.ILike(t.Name, tag));
            if (existing == null) return false;

            try
            {
                _context.Tags.Remove(existing);
                return await _context.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}