using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSABanking.DataAccess.Interfaces;
using TSABanking.DataAccess.Models;
using TSABanking.Services.Interfaces;

namespace TSABanking.Services
{
    public class TerminationQueueService: ITerminationQueueService
    {
        private readonly ITerminationQueueRepository _terminationQueueRepository;
        public TerminationQueueService(ITerminationQueueRepository terminationQueueRepository)
        {
            _terminationQueueRepository = terminationQueueRepository;
        }
        public async Task DeleteAsync(TerminationQueue job)
        {
            await _terminationQueueRepository.DeleteAsync(job);
        }

        public async Task<TerminationQueue> DetailsAsync(int id)
        {
            return await _terminationQueueRepository.DetailsAsync(id);
        }

        public IEnumerable<TerminationQueue> GetTerminationQueues()
        {
            return _terminationQueueRepository.GetTerminationQueues();
        }

        public async Task InsertAsync(TerminationQueue job)
        {
            await _terminationQueueRepository.InsertAsync(job);
        }

        public async Task UpdateAsync(TerminationQueue job)
        {
            await _terminationQueueRepository.UpdateAsync(job);
        }
    }
}
