using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSABanking.DataAccess.Models;

namespace TSABanking.Services.Interfaces
{
    public interface IJobQueueService
    {
        Task DeleteAsync(JobChangeQueue job);
        Task<JobChangeQueue> DetailsAsync(int id);
        IEnumerable<JobChangeQueue> GetJobChangeQueues();
        Task InsertAsync(JobChangeQueue job);
        Task UpdateAsync(JobChangeQueue job);
    }
}
