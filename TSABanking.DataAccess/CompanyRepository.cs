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
    public class CompanyRepository : ICompanyRepository
    {
        private readonly TsabankingContext _context;
        public CompanyRepository(TsabankingContext context)
        {
            _context = context;
        }
        public async Task DeleteAsync(Company user)
        {
            _context.Companies.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<Company> DetailsAsync(int id)
        {
            return await _context.Companies?.FirstOrDefaultAsync(m => m.Id == id);
        }

        public IEnumerable<Company> GetCompanies()
        {
            return _context.Companies.AsQueryable();
        }

        public async Task InsertAsync(Company user)
        {
            _context.Companies.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Company user)
        {
            _context.Attach(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(user.Id))
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
            return (_context.Companies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
