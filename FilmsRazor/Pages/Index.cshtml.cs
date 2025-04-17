using FilmsRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FilmsRazor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly MovieContext context;
        public List<Movie> Movies { get; set; }
        public IndexModel(MovieContext c) { context = c; }
        public void OnGet() { Movies = context.Movies.ToList(); }
    }
}
