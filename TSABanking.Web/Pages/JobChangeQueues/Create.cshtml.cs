using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TSABanking.DataAccess.Models;
using TSABanking.Services.Interfaces;

namespace TSABanking.Web.Pages.JobChangeQueues
{
    public class CreateModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IJobService _jobService;
        private readonly IJobQueueService _jobQueueService;

        public CreateModel(IUserService userService, IJobService jobService, IJobQueueService jobQueueService)
        {
            _userService = userService;
            _jobService = jobService;
            _jobQueueService = jobQueueService;
        }

        public IActionResult OnGet()
        {
            var jobs = _jobService.GetJobs();
            var users = _userService.GetUsers().Select(s => new
            {
                s.Id,
                Name = $"{s.FirstName} {s.MiddleInitial} {s.LastName}",
                TypeName = s.UserTypeNavigation.Name
            });
            ViewData["NewJobId"] = new SelectList(jobs, "Id", "Name");
            ViewData["OldJobId"] = new SelectList(jobs, "Id", "Name");
            ViewData["SuperVisorId"] = new SelectList(users.Where(s => s.TypeName == "SUPERVISOR"), "Id", "Name");
            ViewData["UserId"] = new SelectList(users.Where(s => (s.TypeName != "SUPERVISOR")), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public JobChangeQueue JobChangeQueue { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            JobChangeQueue.CreatedBy = "A001";
            JobChangeQueue.CreatedDate = DateTime.Now;
            await _jobQueueService.InsertAsync(JobChangeQueue);
            return RedirectToPage("./Index");
        }
    }
}
