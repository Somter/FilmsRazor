using FilmsRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FilmsRazor.Pages
{
    public class CreateModel : PageModel
    {
        private readonly MovieContext context;
        private readonly IWebHostEnvironment env;
        [BindProperty] public Movie Movie { get; set; }
        [BindProperty] public IFormFile UploadedPoster { get; set; }
        public CreateModel(MovieContext c, IWebHostEnvironment e) { context = c; env = e; }
        public void OnGet() { }
        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("Movie.Poster");
            if (!ModelState.IsValid) return Page();
            if (UploadedPoster != null)
            {
                string fileName = Path.GetFileName(UploadedPoster.FileName);
                string rel = "/img/" + fileName;
                string full = Path.Combine(env.WebRootPath, "img", fileName);
                using var s = new FileStream(full, FileMode.Create);
                await UploadedPoster.CopyToAsync(s);
                Movie.Poster = rel;
            }
            context.Movies.Add(Movie);
            await context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
