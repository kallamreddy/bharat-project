using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSABanking.DataAccess.Models;

namespace TSABanking.DataAccess.Interfaces
{
    public interface ITerminationQueueRepository
    {
        IEnumerable<TerminationQueue> GetTerminationQueues();
        Task<bool> UpdateAsync(TerminationQueue job);
        Task InsertAsync(TerminationQueue job);
        Task DeleteAsync(TerminationQueue job);
        Task<TerminationQueue> DetailsAsync(int id);
    }
}
