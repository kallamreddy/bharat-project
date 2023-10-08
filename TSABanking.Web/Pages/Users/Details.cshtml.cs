using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TSABanking.DataAccess.Models;
using TSABanking.Services.Interfaces;

namespace TSABanking.Web.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IBankService _bankService;

        public DetailsModel(IUserService userService, IBankService bankService)
        {
            _userService = userService;
            _bankService = bankService;
        }

        public User User { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var banks = new SelectList(_bankService.Getbanks(), "Id", "BankName");
            var user = await _userService.DetailsAsync((int)id);
            if (user == null)
            {
                return NotFound();
            }
            else 
            {
                foreach (var userBank in user.UserBanks)
                {
                    var bankName = banks.FirstOrDefault(d => d.Value == userBank.BankId.ToString())?.Text;
                    user.SelectedBanks.Add(bankName);
                }
                User = user;
            }
            return Page();
        }
    }
}
