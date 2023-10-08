using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TSABanking.DataAccess.Interfaces;
using TSABanking.DataAccess.Models;
using TSABanking.Services.Interfaces;

namespace TSABanking.Web.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IPickListMasterService _pickListMasterService;
        private readonly IBankService _bankService;

        public CreateModel(IUserService userService, IPickListMasterService pickListMasterService, IBankService bankService)
        {
            _userService = userService;
            _pickListMasterService = pickListMasterService;
            _bankService = bankService;
        }

        public IActionResult OnGet()
        {
            ViewData["UserType"] = new SelectList(_pickListMasterService.GetPickListMasterList("USRTYPE"), "Id", "Name");
            ViewData["BankId"] = new SelectList(_bankService.Getbanks(), "Id", "BankName");
            return Page();
        }

        [BindProperty]
        public User User { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            User.CreatedBy = "A001";
            User.CreatedDate = DateTime.Now;
            if (User == null)
            {
                return Page();
            }

            await _userService.InsertAsync(User);

            return RedirectToPage("./Index");
        }
    }
}
