using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSABanking.DataAccess.Models;

namespace TSABanking.DataAccess.Interfaces
{
    public interface IJobRepository
    {
        IEnumerable<Job> GetJobs();
        Task<bool> UpdateAsync(Job job);
        Task InsertAsync(Job job);
        Task DeleteAsync(Job job);
        Task<Job> DetailsAsync(int id);
    }
}
