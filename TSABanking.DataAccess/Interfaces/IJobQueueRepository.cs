using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSABanking.DataAccess.Models;

namespace TSABanking.DataAccess.Interfaces
{
    public interface IJobQueueRepository
    {
        IEnumerable<JobChangeQueue> GetJobChangeQueues();
        Task<bool> UpdateAsync(JobChangeQueue job);
        Task InsertAsync(JobChangeQueue job);
        Task DeleteAsync(JobChangeQueue job);
        Task<JobChangeQueue> DetailsAsync(int id);
    }
}
