using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SummitSchool.Models;
using System.Threading.Tasks;

namespace SummitSchool.Areas.Admin.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly SummitSchool.Data.ApplicationDbContext _context;

        public DetailsModel(SummitSchool.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie.FirstOrDefaultAsync(m => m.ID == id);

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
