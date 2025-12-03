using NIHComicViewer.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIHComicViewer.Application.Services
{
    public class TagAppService : ITagAppService
    {
        public async Task<bool> AddTagAsync(string tag)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteTagAsync(string tag)
        {
            throw new NotImplementedException();
        }

        public async Task<List<string>> GetTagsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateTagAsync(string oldTag, string newTag)
        {
            throw new NotImplementedException();
        }
    }
}
