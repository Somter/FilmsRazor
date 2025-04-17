using FilmsRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FilmsRazor.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly MovieContext context;
        public Movie Movie { get; set; }
        public DetailsModel(MovieContext c) { context = c; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Movie = await context.Movies.FindAsync(id);
            if (Movie == null) return NotFound();
            return Page();
        }
    }
}
