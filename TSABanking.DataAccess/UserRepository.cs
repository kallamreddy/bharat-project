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
    public class UserRepository : IUserRepository
    {
        private readonly TsabankingContext _context;
        public UserRepository(TsabankingContext context)
        {
            _context = context;
        }
        public async Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteuserBanksAsync(User user)
        {
            var userBanks = _context.UserBanks.Where(s => s.UserId == user.Id).ToList();
            foreach (var userBank in userBanks)
            {
                _context.UserBanks.Remove(userBank);
            }
            await _context.SaveChangesAsync();
        }
        public async Task DeleteBankUserssAsync(Bank bank)
        {
            var userBanks = _context.UserBanks.Where(s => s.BankId == bank.Id).ToList();
            foreach (var userBank in userBanks)
            {
                _context.UserBanks.Remove(userBank);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<User> DetailsAsync(int id)
        {
            return await _context.Users
                .Include(s => s.UserTypeNavigation)
                .Include(s => s.UserBanks)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users
                .Include(s => s.UserTypeNavigation)
                .Include(s => s.UserBanks)
                .AsQueryable();
        }

        public async Task InsertAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(User user)
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
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
