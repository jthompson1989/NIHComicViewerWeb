using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIHComicViewer.Application.Models
{
    public class ComicPageModel
    {
        public int Id { get; set; }
        public int ComicId { get; set; }
        public int PageNumber { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
    }
}
