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
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }
        public async Task DeleteAsync(Job job)
        {
            await _jobRepository.DeleteAsync(job);
        }

        public async Task<Job> DetailsAsync(int id)
        {
            return await _jobRepository.DetailsAsync(id);
        }

        public IEnumerable<Job> GetJobs()
        {
            return _jobRepository.GetJobs();
        }

        public async Task InsertAsync(Job job)
        {
            await _jobRepository.InsertAsync(job);
        }

        public async Task UpdateAsync(Job job)
        {
            await _jobRepository.UpdateAsync(job);
        }
    }
}
