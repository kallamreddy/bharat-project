using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TSABanking.DataAccess.Models;
using TSABanking.Services.Interfaces;

namespace TSABanking.Web.Pages.Jobs
{
    public class DeleteModel : PageModel
    {
        private readonly IJobService _jobService;

        public DeleteModel(IJobService jobService)
        {
            _jobService = jobService;
        }

        [BindProperty]
      public Job Job { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _jobService.DetailsAsync((int)id);

            if (job == null)
            {
                return NotFound();
            }
            else 
            {
                Job = job;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var job = await _jobService.DetailsAsync((int)id);
            await _jobService.DeleteAsync(job);
            return RedirectToPage("./Index");
        }
    }
}
