using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TSABanking.DataAccess.Models;
using TSABanking.Services;
using TSABanking.Services.Interfaces;

namespace TSABanking.Web.Pages.Banks
{
    public class EditModel : PageModel
    {
        private readonly IBankService _bankService;
        private readonly IPickListMasterService _pickListMasterService;
        private readonly ICompanyService _companyService;
        private readonly IUserService _userService;

        public EditModel(IBankService bankService, IPickListMasterService pickListMasterService, ICompanyService companyService, IUserService userService)
        {
            _bankService = bankService;
            _pickListMasterService = pickListMasterService;
            _companyService = companyService;
            _userService = userService;
        }

        [BindProperty]
        public Bank Bank { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            ViewData["CompanyId"] = new SelectList(_companyService.GetCompanies(), "Id", "Name");
            ViewData["Platform"] = new SelectList(_pickListMasterService.GetPickListMasterList("PLATFORM"), "Id", "Name");
            var users = _userService.GetUsers().Select(s => new
            {
                s.Id,
                Name = $"{s.FirstName} {s.MiddleInitial} {s.LastName}"
            });
            ViewData["UserId"] = new SelectList(users, "Id", "Name");
            if (id == null)
            {
                return NotFound();
            }

            var bank =  await _bankService.DetailsAsync((int)id);
            if (bank == null)
            {
                return NotFound();
            }
            if (bank.UserBanks.Any())
            {
                foreach (int userId in bank.UserBanks.Select(s => s.UserId))
                {
                    bank.SelectedUsers.Add(userId.ToString());
                }
            }
            Bank = bank;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Bank.ModifiedDate = DateTime.Now;
            Bank.ModifiedBy = "A001";
            await _bankService.UpdateAsync(Bank);
            return RedirectToPage("./Index");
        }
    }
}
