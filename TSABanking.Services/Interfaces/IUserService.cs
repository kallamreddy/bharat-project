using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSABanking.DataAccess.Models;

namespace TSABanking.Services.Interfaces
{
    public interface IUserService
    {
        Task DeleteAsync(User user);
        Task<User> DetailsAsync(int id);
        IEnumerable<User> GetUsers();
        Task InsertAsync(User user);
        Task UpdateAsync(User user);
    }
}
