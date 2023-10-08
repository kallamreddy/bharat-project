using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TSABanking.DataAccess.Models;
using TSABanking.Services.Interfaces;

namespace TSABanking.Web.Pages.Jobs
{
    public class IndexModel : PageModel
    {
        private readonly IJobService _jobService;

        public IndexModel(IJobService jobService)
        {
            _jobService = jobService;
        }

        public IList<Job> Job { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Job= _jobService.GetJobs().ToList();
        }
    }
}
