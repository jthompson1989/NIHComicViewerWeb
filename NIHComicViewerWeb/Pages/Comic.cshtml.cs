using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NIHComicViewer.Application.Services.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace NIHComicViewer.Web.Pages
{
    public class ComicModel : PageModel
    {
        private readonly IComicAppService _comicAppService;
        public NIHComicViewer.Application.Models.ComicModel Comic { get; private set; }

        public string ComicJson { get; private set; }

        public ComicModel(IComicAppService comicAppService)
        {
            _comicAppService = comicAppService ?? throw new ArgumentNullException(nameof(comicAppService));
        }

        public async Task OnGetAsync()
        {
            Comic = await _comicAppService.GetComicByIdAsync(2);
        }
    }
}
