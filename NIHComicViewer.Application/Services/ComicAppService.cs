using NIHComicViewer.Application.Models;
using NIHComicViewer.Application.Services.Interfaces;
using NIHComicViewer.Infrastructure.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIHComicViewer.Application.Services
{
    public class ComicAppService : IComicAppService
    {
        private IUnitOfWork _unitOfWork;
        public ComicAppService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddComicAsync(ComicModel comicModel)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteComicAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<ComicModel?> GetComicByIdAsync(long id)
        {
            var comic = await _unitOfWork.ComicRepository.GetComicByIdAsync(id);
            if(comic != null)
            {
                return new ComicModel()
                {
                    Title = comic.Name,
                    Author = comic.Author,
                    Language = comic.Language ?? "",
                    CoverImagePath = comic.Cover ?? "",
                    CreatedAt = comic.CreatedDate ?? DateTime.MinValue,
                    UpdatedAt = comic.ModifiedDate ?? DateTime.MinValue,
                    Id = (int)comic.Id,
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<List<ComicModel>> GetComicsAsync(int pageNumber = 1, int count = 20)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ComicModel>> GetComicsByAuthorAsync(string author, int pageNumber = 1, int count = 20)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ComicModel>> GetComicsByLanguageAsync(string language, int pageNumber = 1, int count = 20)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ComicModel>> GetComicsByTagsAsync(string[] tags, int pageNumber = 1, int count = 20)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ComicModel>> GetComicsByYearAsync(string year, int pageNumber = 1, int count = 20)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateComicAsync(ComicModel comicModel)
        {
            throw new NotImplementedException();
        }
    }
}
