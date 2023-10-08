using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TSABanking.DataAccess.Models;
using TSABanking.Services.Interfaces;

namespace TSABanking.Web.Pages.TerminationQueues
{
    public class EditModel : PageModel
    {
        private readonly ITerminationQueueService _terminationQueueService;
        private readonly IUserService _userService;
        private readonly IBankService _bankService;
        private readonly ICompanyService _companyService;
        public EditModel(IUserService userService, IBankService bankService, ITerminationQueueService terminationQueueService, ICompanyService companyService)
        {
            _userService = userService;
            _bankService = bankService;
            _terminationQueueService = terminationQueueService;
            _companyService = companyService;
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
            var users = _userService.GetUsers().Select(s => new
            {
                s.Id,
                Name = $"{s.FirstName} {s.MiddleInitial} {s.LastName}",
                TypeName = s.UserTypeNavigation.Name
            });
            TerminationQueue = terminationqueue;
            ViewData["BankId"] = new SelectList(_bankService.Getbanks(), "Id", "BankName");
            ViewData["CompanyId"] = new SelectList(_companyService.GetCompanies(), "Id", "Name");
            ViewData["SuperVisorId"] = new SelectList(users.Where(s => s.TypeName == "SUPERVISOR"), "Id", "Name");
            ViewData["UserId"] = new SelectList(users.Where(s => (s.TypeName != "SUPERVISOR")), "Id", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            TerminationQueue.ModifiedBy = "A001";
            TerminationQueue.ModifiedDate = DateTime.Now;
            await _terminationQueueService.UpdateAsync(TerminationQueue);
            return RedirectToPage("./Index");
        }

    }
}
