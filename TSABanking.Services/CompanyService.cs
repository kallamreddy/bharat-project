using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSABanking.DataAccess.Interfaces;
using TSABanking.DataAccess.Models;
using TSABanking.Services.Interfaces;

namespace TSABanking.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public async Task DeleteAsync(Company Company)
        {
            await _companyRepository.DeleteAsync(Company);
        }

        public async Task<Company> DetailsAsync(int id)
        {
            return await _companyRepository.DetailsAsync(id);
        }

        public IEnumerable<Company> GetCompanies()
        {
            return _companyRepository.GetCompanies();
        }

        public async Task InsertAsync(Company Company)
        {
            await _companyRepository.InsertAsync(Company);
        }

        public async Task UpdateAsync(Company Company)
        {
            await _companyRepository.UpdateAsync(Company);
        }
    }
}
