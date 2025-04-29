using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIHComicViewer.Infrastructure.Repositories
{
    public interface ITagRepository
    {
        Task<List<string>> GetTagsAsync();
        Task<bool> AddTagAsync(string tag);
        Task<bool> UpdateTagAsync(string oldTag, string newTag);
        Task<bool> DeleteTagAsync(string tag);
    }
}
