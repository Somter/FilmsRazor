using FilmsRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FilmsRazor.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly MovieContext context;
        private readonly IWebHostEnvironment env;
        [BindProperty] public Movie Movie { get; set; }
        public DeleteModel(MovieContext c, IWebHostEnvironment e) { context = c; env = e; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Movie = await context.Movies.FindAsync(id);
            if (Movie == null) return NotFound();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var m = await context.Movies.FindAsync(Movie.Id);
            if (m != null)
            {
                if (!string.IsNullOrEmpty(m.Poster) && m.Poster.StartsWith("/images/"))
                {
                    string p = Path.Combine(env.WebRootPath, m.Poster.TrimStart('/'));
                    if (System.IO.File.Exists(p)) System.IO.File.Delete(p);
                }
                context.Movies.Remove(m);
                await context.SaveChangesAsync();
            }
            return RedirectToPage("Index");
        }
    }
}
