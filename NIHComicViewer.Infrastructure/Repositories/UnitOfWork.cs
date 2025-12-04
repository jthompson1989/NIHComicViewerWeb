using Microsoft.EntityFrameworkCore;
using NIHComicViewer.Infrastructure.Entities;
using NIHComicViewer.Infrastructure.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace NIHComicViewer.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IComicRepository _comicRepository;

        private IComicPageRepository _comicPageRepository;

        private ITagRepository _tagRepository;

        private IUserRepository _userRepository;

        private NihcomicContext _context;

        public UnitOfWork(NihcomicContext context,
            IComicRepository comicRepository,
            IComicPageRepository comicPageRepository,
            ITagRepository tagRepository,
            IUserRepository userRepository)
        {
            _context = context;
            _comicRepository = comicRepository;
            _comicPageRepository = comicPageRepository;
            _tagRepository = tagRepository;
            _userRepository = userRepository;
        }

        public IComicRepository ComicRepository => _comicRepository ??= new ComicRepository(_context);

        public IComicPageRepository ComicPageRepository => _comicPageRepository ??= new ComicPageRepository(_context);

        public ITagRepository TagRepository => _tagRepository ??= new TagRepository(_context);

        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
