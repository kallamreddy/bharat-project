using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSABanking.DataAccess.Models;

namespace TSABanking.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        Task<bool> UpdateAsync(User user);
        Task InsertAsync(User user);
        Task DeleteAsync(User user);
        Task<User> DetailsAsync(int id);
        Task DeleteuserBanksAsync(User user);
        Task DeleteBankUserssAsync(Bank bank);
    }
}
