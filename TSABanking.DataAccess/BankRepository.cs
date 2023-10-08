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
    public class BankRepository : IBankRepository
    {
        private readonly TsabankingContext _context;
        public BankRepository(TsabankingContext context)
        {
            _context = context;
        }
        public async Task DeleteAsync(Bank user)
        {
            _context.Banks.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<Bank> DetailsAsync(int id)
        {
            return await _context.Banks
                .Include(d => d.PlatformNavigation)
                .Include(d => d.Company)
                .Include(d => d.UserBanks)
                ?.FirstOrDefaultAsync(m => m.Id == id);
        }

        public IEnumerable<Bank> GetBanks()
        {
            return _context.Banks
                .Include(d => d.PlatformNavigation)
                .Include(d => d.Company)
                .Include(d => d.UserBanks)
                .AsQueryable();
        }

        public async Task InsertAsync(Bank user)
        {
            _context.Banks.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Bank user)
        {
            _context.Attach(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankExists(user.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

        }
        private bool BankExists(int id)
        {
            return (_context.Banks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
