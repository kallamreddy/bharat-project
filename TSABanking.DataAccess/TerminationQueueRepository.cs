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
    public class TerminationQueueRepository: ITerminationQueueRepository
    {
        private readonly TsabankingContext _context;
        public TerminationQueueRepository(TsabankingContext context)
        {
            _context = context;
        }
        public async Task DeleteAsync(TerminationQueue jobChangeQueue)
        {
            _context.TerminationQueues.Remove(jobChangeQueue);
            await _context.SaveChangesAsync();
        }

        public async Task<TerminationQueue> DetailsAsync(int id)
        {
            return await _context.TerminationQueues?
                .Include(s => s.SuperVisor)
                .Include(s => s.Bank)
                .Include(s => s.Company)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public IEnumerable<TerminationQueue> GetTerminationQueues()
        {
            return _context.TerminationQueues
                .Include(s=>s.SuperVisor)
                .Include(s=>s.Bank)
                .Include(s=>s.Company)
                .Include(s=>s.User)
                .AsQueryable();
        }

        public async Task InsertAsync(TerminationQueue job)
        {
            _context.TerminationQueues.Add(job);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(TerminationQueue job)
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
            return (_context.TerminationQueues?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
