using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TSABanking.DataAccess.Models;
using TSABanking.Services;
using TSABanking.Services.Interfaces;

namespace TSABanking.Web.Pages.Banks
{
    public class CreateModel : PageModel
    {
        private readonly IBankService _bankService;
        private readonly IPickListMasterService _pickListMasterService;
        private readonly ICompanyService _companyService;
        private readonly IUserService _userService;

        public CreateModel(IBankService bankService, IPickListMasterService pickListMasterService, ICompanyService companyService, IUserService userService)
        {
            _bankService = bankService;
            _pickListMasterService = pickListMasterService;
            _companyService = companyService;
            _userService = userService;
        }

        public IActionResult OnGet()
        {
            var users = _userService.GetUsers().Select(s => new
            {
                s.Id,
                Name = $"{s.FirstName} {s.MiddleInitial} {s.LastName}"
            });
            ViewData["UserId"] = new SelectList(users, "Id", "Name");
            ViewData["CompanyId"] = new SelectList(_companyService.GetCompanies(), "Id", "Name");
            ViewData["Platform"] = new SelectList(_pickListMasterService.GetPickListMasterList("PLATFORM"), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Bank Bank { get; set; } = default!;


        public async Task<IActionResult> OnPostAsync()
        {
            Bank.CreatedBy = "A001";
            Bank.CreatedDate = DateTime.Now;
            if (Bank == null)
            {
                return Page();
            }
            await _bankService.InsertAsync(Bank);
            return RedirectToPage("./Index");
        }
    }
}
