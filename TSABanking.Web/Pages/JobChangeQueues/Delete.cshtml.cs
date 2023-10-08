using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TSABanking.DataAccess.Models;
using TSABanking.Services.Interfaces;

namespace TSABanking.Web.Pages.JobChangeQueues
{
    public class DeleteModel : PageModel
    {
        private readonly IJobQueueService _jobQueueService;

        public DeleteModel(IJobQueueService jobQueueService)
        {
            _jobQueueService = jobQueueService;
        }

        [BindProperty]
        public JobChangeQueue JobChangeQueue { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobchangequeue = await _jobQueueService.DetailsAsync((int)id);

            if (jobchangequeue == null)
            {
                return NotFound();
            }
            else
            {
                JobChangeQueue = jobchangequeue;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var jobchangequeue = await _jobQueueService.DetailsAsync((int)id);

            if (jobchangequeue != null)
            {
                JobChangeQueue = jobchangequeue;
                await _jobQueueService.DeleteAsync(JobChangeQueue);
            }
            return RedirectToPage("./Index");
        }
    }
}
