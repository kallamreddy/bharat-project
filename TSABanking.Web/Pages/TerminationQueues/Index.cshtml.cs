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
    public class IndexModel : PageModel
    {
        private readonly ITerminationQueueService _terminationQueueService;

        public IndexModel(ITerminationQueueService terminationQueueService)
        {
            _terminationQueueService = terminationQueueService;
        }

        public IList<TerminationQueue> TerminationQueue { get;set; } = default!;

        public async Task OnGetAsync()
        {
            TerminationQueue = _terminationQueueService.GetTerminationQueues().ToList();
        }
    }
}
