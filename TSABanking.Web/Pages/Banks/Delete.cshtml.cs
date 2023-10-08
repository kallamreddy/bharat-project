using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TSABanking.DataAccess.Models;
using TSABanking.Services.Interfaces;

namespace TSABanking.Web.Pages.Banks
{
    public class DeleteModel : PageModel
    {
        private readonly IBankService _bankService;

        public DeleteModel(IBankService bankService)
        {
            _bankService = bankService;
        }

        [BindProperty]
        public Bank Bank { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bank = await _bankService.DetailsAsync((int)id);

            if (bank == null)
            {
                return NotFound();
            }
            else
            {
                Bank = bank;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var bank = await _bankService.DetailsAsync((int)id);

            if (bank != null)
            {
                Bank = bank;
                await _bankService.DeleteAsync(Bank);
            }

            return RedirectToPage("./Index");
        }
    }
}
