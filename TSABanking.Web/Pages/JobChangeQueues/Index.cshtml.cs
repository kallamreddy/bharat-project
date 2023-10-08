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
    public class IndexModel : PageModel
    {
        private readonly IJobQueueService _jobQueueService;

        public IndexModel(IJobQueueService jobQueueService)
        {
            _jobQueueService = jobQueueService;
        }

        public IList<JobChangeQueue> JobChangeQueue { get; set; } = default!;

        public async Task OnGetAsync()
        {
            JobChangeQueue = _jobQueueService.GetJobChangeQueues().ToList();
        }
    }
}
