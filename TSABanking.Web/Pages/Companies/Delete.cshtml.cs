using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TSABanking.DataAccess.Models;
using TSABanking.Services.Interfaces;

namespace TSABanking.Web.Pages.Companies
{
    public class DeleteModel : PageModel
    {
        private readonly ICompanyService _companyService;

        public DeleteModel(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        [BindProperty]
      public Company Company { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _companyService.DetailsAsync((int)id);

            if (company == null)
            {
                return NotFound();
            }
            else 
            {
                Company = company;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var company = await _companyService.DetailsAsync((int)id);

            if (company != null)
            {
                Company = company;
                await _companyService.DeleteAsync(Company);
            }

            return RedirectToPage("./Index");
        }
    }
}
