using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SummitSchool.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Summit.Areas.User.Pages.Library
{
    public class IndexModel : PageModel
    {
        private readonly SummitSchool.Data.ApplicationDbContext _context;


        public IndexModel(SummitSchool.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get; set; }

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
    }
}
