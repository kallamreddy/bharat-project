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
    public class IndexModel : PageModel
    {
        private readonly TSABanking.DataAccess.Models.TsabankingContext _context;

        public IndexModel(TSABanking.DataAccess.Models.TsabankingContext context)
        {
            _context = context;
        }

        public IList<UserBank> UserBank { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.UserBanks != null)
            {
                UserBank = await _context.UserBanks
                .Include(u => u.Bank)
                .Include(u => u.User).ToListAsync();
            }
        }
    }
}
