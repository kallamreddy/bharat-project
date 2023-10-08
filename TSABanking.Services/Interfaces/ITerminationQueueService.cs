using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSABanking.DataAccess.Models;

namespace TSABanking.Services.Interfaces
{
    public interface ITerminationQueueService
    {
        Task DeleteAsync(TerminationQueue job);
        Task<TerminationQueue> DetailsAsync(int id);
        IEnumerable<TerminationQueue> GetTerminationQueues();
        Task InsertAsync(TerminationQueue job);
        Task UpdateAsync(TerminationQueue job);
    }
}
