using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TSABanking.DataAccess.Models;

namespace TSABanking.Web.Pages.UserBanks
{
    public class DeleteModel : PageModel
    {
        private readonly TSABanking.DataAccess.Models.TsabankingContext _context;

        public DeleteModel(TSABanking.DataAccess.Models.TsabankingContext context)
        {
            _context = context;
        }

        [BindProperty]
      public UserBank UserBank { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UserBanks == null)
            {
                return NotFound();
            }

            var userbank = await _context.UserBanks.FirstOrDefaultAsync(m => m.Id == id);

            if (userbank == null)
            {
                return NotFound();
            }
            else 
            {
                UserBank = userbank;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.UserBanks == null)
            {
                return NotFound();
            }
            var userbank = await _context.UserBanks.FindAsync(id);

            if (userbank != null)
            {
                UserBank = userbank;
                _context.UserBanks.Remove(UserBank);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
