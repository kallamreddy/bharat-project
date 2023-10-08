using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSABanking.DataAccess.Models;

namespace TSABanking.DataAccess.Interfaces
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetCompanies();
        Task<bool> UpdateAsync(Company user);
        Task InsertAsync(Company user);
        Task DeleteAsync(Company user);
        Task<Company> DetailsAsync(int id);
    }
}
