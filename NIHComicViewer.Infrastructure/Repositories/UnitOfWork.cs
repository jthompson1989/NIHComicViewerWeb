using System;
using System.Threading.Tasks;
using NIHComicViewer.Infrastructure.Entities;
using NIHComicViewer.Infrastructure.Repositories.Interface;

namespace NIHComicViewer.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IComicRepository _comicRepository;
        private readonly IComicPageRepository _comicPageRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IUserRepository _userRepository;
        private readonly NihcomicContext _context;

        public UnitOfWork(
            NihcomicContext context,
            IComicRepository comicRepository,
            IComicPageRepository comicPageRepository,
            ITagRepository tagRepository,
            IUserRepository userRepository)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _comicRepository = comicRepository ?? throw new ArgumentNullException(nameof(comicRepository));
            _comicPageRepository = comicPageRepository ?? throw new ArgumentNullException(nameof(comicPageRepository));
            _tagRepository = tagRepository ?? throw new ArgumentNullException(nameof(tagRepository));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public IComicRepository ComicRepository => _comicRepository;
        public IComicPageRepository ComicPageRepository => _comicPageRepository;
        public ITagRepository TagRepository => _tagRepository;
        public IUserRepository UserRepository => _userRepository;

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        // Do not dispose the DbContext here; the DI container manages scoped disposals.
        public void Dispose()
        {
            // Intentionally left blank or use GC.SuppressFinalize(this) if needed.
        }
    }
}
