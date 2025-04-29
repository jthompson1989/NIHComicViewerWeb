using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NIHComicViewer.Infrastructure.Entities;

namespace NIHComicViewer.Infrastructure.Repositories
{
    public interface IComicRepository
    {
        Task<List<Comic>> GetComicsAsync();
        Task<Comic?> GetComicByIdAsync(long id);
        Task<List<Comic>> GetComicsByAuthorAsync(string author, int pageNumber = 1, int count = 20);
        Task<List<Comic>> GetComicsByLanguageAsync(string language, int pageNumber = 1, int count = 20);
        Task<List<Comic>> GetComicsByYearAsync(string year, int pageNumber = 1, int count = 20);
        Task<List<Comic>> GetComicsByTagsAsync(string[] tags, int pageNumber = 1, int count = 20);
        Task<bool> AddComicAsync(Comic comic);
        Task<bool> UpdateComicAsync(Comic comic);
        Task<bool> DeleteComicAsync(long id);
    }
}
