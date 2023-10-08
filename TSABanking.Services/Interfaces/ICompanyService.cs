using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSABanking.DataAccess.Models;

namespace TSABanking.Services.Interfaces
{
    public interface ICompanyService
    {
        Task DeleteAsync(Company bank);
        Task<Company> DetailsAsync(int id);
        IEnumerable<Company> GetCompanies();
        Task InsertAsync(Company bank);
        Task UpdateAsync(Company bank);
    }
}
