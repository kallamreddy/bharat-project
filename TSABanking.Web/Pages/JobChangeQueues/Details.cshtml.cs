using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TSABanking.DataAccess.Models;
using TSABanking.Services.Interfaces;

namespace TSABanking.Web.Pages.JobChangeQueues
{
    public class DetailsModel : PageModel
    {
        private readonly IJobQueueService _jobQueueService;

        public DetailsModel(IJobQueueService jobQueueService)
        {
            _jobQueueService = jobQueueService;
        }

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
    }
}
