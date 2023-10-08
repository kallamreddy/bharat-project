using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TSABanking.DataAccess.Models;
using TSABanking.Services.Interfaces;

namespace TSABanking.Web.Pages.Jobs
{
    public class CreateModel : PageModel
    {
        private readonly IJobService _jobService;

        public CreateModel(IJobService jobService)
        {
            _jobService = jobService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Job Job { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Job == null)
            {
                return Page();
            }

            await _jobService.InsertAsync(Job);
            return RedirectToPage("./Index");
        }
    }
}
