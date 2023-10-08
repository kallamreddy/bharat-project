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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) {
            _userRepository = userRepository;
        }
        public async Task DeleteAsync(User user)
        {
           await _userRepository.DeleteAsync(user);
        }

        public async Task<User> DetailsAsync(int id)
        {
            return await _userRepository.DetailsAsync(id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public async Task InsertAsync(User user)
        {
            if(user.SelectedBanks.Any())
            {
                foreach(string bankId in user.SelectedBanks)
                {
                    user.UserBanks.Add(new UserBank()
                    {
                        BankId = Convert.ToInt32(bankId)
                    });
                }
            }
            await _userRepository.InsertAsync(user);
        }

        public async Task UpdateAsync(User user)
        {
            await _userRepository.DeleteuserBanksAsync(user);
            user.UserBanks=new List<UserBank>();
            foreach (string bankId in user.SelectedBanks)
            {
                user.UserBanks.Add(new UserBank()
                {
                    BankId = Convert.ToInt32(bankId)
                });
            }
            await _userRepository.UpdateAsync(user);
        }
    }
}
