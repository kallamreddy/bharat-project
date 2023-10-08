using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TSABanking.DataAccess.Models;
using TSABanking.Services.Interfaces;

namespace TSABanking.Web.Pages.TerminationQueues
{
    public class CreateModel : PageModel
    {
        private readonly ITerminationQueueService _terminationQueueService;
        private readonly IUserService _userService;
        private readonly IBankService _bankService;
        private readonly ICompanyService _companyService;
        public CreateModel(IUserService userService, IBankService bankService, ITerminationQueueService terminationQueueService, ICompanyService companyService)
        {
            _userService = userService;
            _bankService = bankService;
            _terminationQueueService = terminationQueueService;
            _companyService = companyService;
        }

        public IActionResult OnGet()
        {
            var users = _userService.GetUsers().Select(s => new
            {
                s.Id,
                Name = $"{s.FirstName} {s.MiddleInitial} {s.LastName}",
                TypeName = s.UserTypeNavigation.Name
            });
            ViewData["BankId"] = new SelectList(_bankService.Getbanks(), "Id", "BankName");
            ViewData["CompanyId"] = new SelectList(_companyService.GetCompanies(), "Id", "Name");
            ViewData["SuperVisorId"] = new SelectList(users.Where(s => s.TypeName == "SUPERVISOR"), "Id", "Name");
            ViewData["UserId"] = new SelectList(users.Where(s => (s.TypeName != "SUPERVISOR")), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public TerminationQueue TerminationQueue { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            TerminationQueue.CreatedBy = "A001";
            TerminationQueue.CreatedDate = DateTime.Now;
            await _terminationQueueService.InsertAsync(TerminationQueue);
            return RedirectToPage("./Index");
        }
    }
}
