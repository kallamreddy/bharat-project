using Microsoft.AspNetCore.Mvc.RazorPages;
using TSABanking.DataAccess.Models;
using TSABanking.Services.Interfaces;

namespace TSABanking.Web.Pages.Companies
{
    public class IndexModel : PageModel
    {
        private readonly ICompanyService _companyService;

        public IndexModel(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public IList<Company> Company { get;set; } = default!;

        public async Task OnGetAsync()
        {
                Company = _companyService.GetCompanies().ToList();
        }
    }
}
