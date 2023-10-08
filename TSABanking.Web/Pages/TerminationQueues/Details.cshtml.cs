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
    public class DetailsModel : PageModel
    {
        private readonly ITerminationQueueService _terminationQueueService;

        public DetailsModel(ITerminationQueueService terminationQueueService)
        {
            _terminationQueueService = terminationQueueService;
        }

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
    }
}
