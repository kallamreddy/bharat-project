using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TSABanking.DataAccess.Models;

namespace TSABanking.Web.Pages.UserBanks
{
    public class CreateModel : PageModel
    {
        private readonly TSABanking.DataAccess.Models.TsabankingContext _context;

        public CreateModel(TSABanking.DataAccess.Models.TsabankingContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BankId"] = new SelectList(_context.Banks, "Id", "Abreviation");
        ViewData["UserId"] = new SelectList(_context.Users, "Id", "CreatedBy");
            return Page();
        }

        [BindProperty]
        public UserBank UserBank { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.UserBanks == null || UserBank == null)
            {
                return Page();
            }

            _context.UserBanks.Add(UserBank);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
