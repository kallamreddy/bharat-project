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
    public class IndexModel : PageModel
    {
        private readonly IBankService _bankService;

        public IndexModel(IBankService bankService)
        {
            _bankService = bankService;
        }


        public IList<Bank> Bank { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Bank = _bankService.Getbanks().ToList();
        }
    }
}
