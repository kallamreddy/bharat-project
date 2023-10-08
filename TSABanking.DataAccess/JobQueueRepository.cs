using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSABanking.DataAccess.Interfaces;
using TSABanking.DataAccess.Models;

namespace TSABanking.DataAccess
{
    public class JobQueueRepository: IJobQueueRepository
    {
        private readonly TsabankingContext _context;
        public JobQueueRepository(TsabankingContext context)
        {
            _context = context;
        }
        public async Task DeleteAsync(JobChangeQueue jobChangeQueue)
        {
            _context.JobChangeQueues.Remove(jobChangeQueue);
            await _context.SaveChangesAsync();
        }

        public async Task<JobChangeQueue> DetailsAsync(int id)
        {
            return await _context.JobChangeQueues?
                 .Include(d => d.SuperVisor)
                .Include(d => d.OldJob)
                .Include(d => d.NewJob)
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public IEnumerable<JobChangeQueue> GetJobChangeQueues()
        {
            return _context.JobChangeQueues
                .Include(d=>d.SuperVisor)
                .Include(d=>d.OldJob)
                .Include(d=>d.NewJob)
                .Include(d=>d.User)
                .AsQueryable();
        }

        public async Task InsertAsync(JobChangeQueue job)
        {
            _context.JobChangeQueues.Add(job);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(JobChangeQueue job)
        {
            _context.Attach(job).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(job.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

        }
        private bool UserExists(int id)
        {
            return (_context.JobChangeQueues?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
