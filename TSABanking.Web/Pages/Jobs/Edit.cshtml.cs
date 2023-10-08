using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TSABanking.DataAccess.Models;
using TSABanking.Services;
using TSABanking.Services.Interfaces;

namespace TSABanking.Web.Pages.Jobs
{
    public class EditModel : PageModel
    {
        private readonly IJobService _jobService;

        public EditModel(IJobService jobService)
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

            var job =  await _jobService.DetailsAsync((int)id);
            if (job == null)
            {
                return NotFound();
            }
            Job = job;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _jobService.UpdateAsync(Job);
            return RedirectToPage("./Index");
        }
    }
}
