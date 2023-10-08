using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSABanking.DataAccess;
using TSABanking.DataAccess.Interfaces;
using TSABanking.DataAccess.Models;
using TSABanking.Services.Interfaces;

namespace TSABanking.Services
{
    public class BankService : IBankService
    {
        private readonly IBankRepository _bankRepository;
        private readonly IUserRepository _userRepository;
        public BankService(IBankRepository bankRepository, IUserRepository userRepository)
        {
            _bankRepository = bankRepository;
            _userRepository = userRepository;
        }
        public async Task DeleteAsync(Bank bank)
        {
            await _bankRepository.DeleteAsync(bank);
        }

        public async Task<Bank> DetailsAsync(int id)
        {
            return await _bankRepository.DetailsAsync(id);
        }

        public IEnumerable<Bank> Getbanks()
        {
            return _bankRepository.GetBanks();
        }

        public async Task InsertAsync(Bank bank)
        {
            if (bank.SelectedUsers.Any())
            {
                foreach (string userId in bank.SelectedUsers)
                {
                    bank.UserBanks.Add(new UserBank()
                    {
                        BankId = Convert.ToInt32(userId)
                    });
                }
            }
            await _bankRepository.InsertAsync(bank);
        }

        public async Task UpdateAsync(Bank bank)
        {
            await _userRepository.DeleteBankUserssAsync(bank);
            bank.UserBanks = new List<UserBank>();
            foreach (string bankId in bank.SelectedUsers)
            {
                bank.UserBanks.Add(new UserBank()
                {
                    BankId = Convert.ToInt32(bankId)
                });
            }
            await _bankRepository.UpdateAsync(bank);
        }
    }
}
