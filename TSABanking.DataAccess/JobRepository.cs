using Microsoft.EntityFrameworkCore;
using TSABanking.DataAccess.Interfaces;
using TSABanking.DataAccess.Models;

namespace TSABanking.DataAccess
{
    public class JobRepository : IJobRepository
    {
        private readonly TsabankingContext _context;
        public JobRepository(TsabankingContext context)
        {
            _context = context;
        }
        public async Task DeleteAsync(Job job)
        {
            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();
        }

        public async Task<Job> DetailsAsync(int id)
        {
            return await _context.Jobs?.FirstOrDefaultAsync(m => m.Id == id);
        }

        public IEnumerable<Job> GetJobs()
        {
            return _context.Jobs.AsQueryable();
        }

        public async Task InsertAsync(Job job)
        {
            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Job job)
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
            return (_context.Jobs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
