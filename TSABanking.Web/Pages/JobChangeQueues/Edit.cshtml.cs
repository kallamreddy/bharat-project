using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TSABanking.DataAccess.Models;
using TSABanking.Services.Interfaces;

namespace TSABanking.Web.Pages.JobChangeQueues
{
    public class EditModel : PageModel
    {
        private readonly IJobQueueService _jobQueueService;
        private readonly IUserService _userService;
        private readonly IJobService _jobService;

        public EditModel(IUserService userService, IJobService jobService, IJobQueueService jobQueueService)
        {
            _jobQueueService = jobQueueService;
            _userService = userService;
            _jobService = jobService;
        }

        [BindProperty]
        public JobChangeQueue JobChangeQueue { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobchangequeue =  await _jobQueueService.DetailsAsync((int)id);
            if (jobchangequeue == null)
            {
                return NotFound();
            }
            JobChangeQueue = jobchangequeue;
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

        public async Task<IActionResult> OnPostAsync()
        {
            JobChangeQueue.ModifiedBy = "A001";
            JobChangeQueue.ModifiedDate = DateTime.Now;
             await _jobQueueService.UpdateAsync(JobChangeQueue);
            return RedirectToPage("./Index");
        }
    }
}
