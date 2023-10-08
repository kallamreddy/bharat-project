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

namespace TSABanking.Web.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IPickListMasterService _pickListMasterService;
        private readonly IBankService _bankService;

        public EditModel(IUserService userService, IPickListMasterService pickListMasterService, IBankService bankService)
        {
            _userService = userService;
            _pickListMasterService = pickListMasterService;
            _bankService = bankService;
        }

        [BindProperty]
        public User User { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            ViewData["UserType"] = new SelectList(_pickListMasterService.GetPickListMasterList("USRTYPE"), "Id", "Name");
            ViewData["BankId"] = new SelectList(_bankService.Getbanks(), "Id", "BankName");
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userService.DetailsAsync((int)id);
            if (user == null)
            {
                return NotFound();
            }
            if (user.UserBanks.Any())
            {
                foreach (int bankId in user.UserBanks.Select(s => s.BankId))
                {
                    user.SelectedBanks.Add(bankId.ToString());
                }
            }
            User = user;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            User.ModifiedBy = "A001";
            User.ModifiedDate = DateTime.Now;
            await _userService.UpdateAsync(User);
            return RedirectToPage("./Index");
        }
    }
}
