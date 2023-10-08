using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TSABanking.DataAccess.Models;

namespace TSABanking.Web.Pages.UserBanks
{
    public class EditModel : PageModel
    {
        private readonly TSABanking.DataAccess.Models.TsabankingContext _context;

        public EditModel(TSABanking.DataAccess.Models.TsabankingContext context)
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

            var userbank =  await _context.UserBanks.FirstOrDefaultAsync(m => m.Id == id);
            if (userbank == null)
            {
                return NotFound();
            }
            UserBank = userbank;
           ViewData["BankId"] = new SelectList(_context.Banks, "Id", "Abreviation");
           ViewData["UserId"] = new SelectList(_context.Users, "Id", "CreatedBy");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(UserBank).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserBankExists(UserBank.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool UserBankExists(int id)
        {
          return (_context.UserBanks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
