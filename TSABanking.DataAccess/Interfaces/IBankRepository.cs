using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSABanking.DataAccess.Models;

namespace TSABanking.DataAccess.Interfaces
{
    public interface IBankRepository
    {
        IEnumerable<Bank> GetBanks();
        Task<bool> UpdateAsync(Bank user);
        Task InsertAsync(Bank user);
        Task DeleteAsync(Bank user);
        Task<Bank> DetailsAsync(int id);
    }
}
