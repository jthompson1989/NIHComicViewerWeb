using System;
using Microsoft.AspNetCore.Mvc;
using NIHComicViewer.Application.Services;
using NIHComicViewer.Application.Services.Interfaces;
using NIHComicViewer.Application.Models;

namespace NIHComicViewerWeb.Controllers
{
    public class ComicController : Controller
    {
        private readonly IComicAppService _comicAppService;

        public ComicController(IComicAppService comicAppService)
        {
            _comicAppService = comicAppService ?? throw new ArgumentNullException(nameof(comicAppService));
        }

        public async Task<IActionResult> Index()
        {
            var comic = await _comicAppService.GetComicByIdAsync(1);
            return View(comic);
        }
    }
}
