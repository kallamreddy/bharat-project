using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TSABanking.DataAccess.Models;
using TSABanking.Services.Interfaces;

namespace TSABanking.Web.Pages.TerminationQueues
{
    public class DeleteModel : PageModel
    {
        private readonly ITerminationQueueService _terminationQueueService;

        public DeleteModel(ITerminationQueueService terminationQueueService)
        {
            _terminationQueueService = terminationQueueService;
        }

        [BindProperty]
      public TerminationQueue TerminationQueue { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var terminationqueue = await _terminationQueueService.DetailsAsync((int)id);

            if (terminationqueue == null)
            {
                return NotFound();
            }
            else 
            {
                TerminationQueue = terminationqueue;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var terminationqueue = await _terminationQueueService.DetailsAsync((int)id);
            if (terminationqueue != null)
            {
                TerminationQueue = terminationqueue;
                await _terminationQueueService.DeleteAsync(TerminationQueue);
            }
            return RedirectToPage("./Index");
        }
    }
}
