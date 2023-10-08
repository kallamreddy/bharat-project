using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSABanking.DataAccess.Models;

namespace TSABanking.Services.Interfaces
{
    public interface IJobService
    {
        Task DeleteAsync(Job job);
        Task<Job> DetailsAsync(int id);
        IEnumerable<Job> GetJobs();
        Task InsertAsync(Job job);
        Task UpdateAsync(Job job);
    }
}
