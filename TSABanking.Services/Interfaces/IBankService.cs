using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSABanking.DataAccess.Models;

namespace TSABanking.Services.Interfaces
{
    public interface IBankService
    {
        Task DeleteAsync(Bank bank);
        Task<Bank> DetailsAsync(int id);
        IEnumerable<Bank> Getbanks();
        Task InsertAsync(Bank bank);
        Task UpdateAsync(Bank bank);
    }
}
