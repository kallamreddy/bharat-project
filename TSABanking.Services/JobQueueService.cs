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
    public class JobQueueService: IJobQueueService
    {
        private readonly IJobQueueRepository _jobQueueRepository;
        public JobQueueService(IJobQueueRepository jobQueueRepository)
        {
            _jobQueueRepository = jobQueueRepository;
        }
        public async Task DeleteAsync(JobChangeQueue job)
        {
            await _jobQueueRepository.DeleteAsync(job);
        }

        public async Task<JobChangeQueue> DetailsAsync(int id)
        {
            return await _jobQueueRepository.DetailsAsync(id);
        }

        public IEnumerable<JobChangeQueue> GetJobChangeQueues()
        {
            return _jobQueueRepository.GetJobChangeQueues();
        }

        public async Task InsertAsync(JobChangeQueue job)
        {
            await _jobQueueRepository.InsertAsync(job);
        }

        public async Task UpdateAsync(JobChangeQueue job)
        {
            await _jobQueueRepository.UpdateAsync(job);
        }
    }
}
