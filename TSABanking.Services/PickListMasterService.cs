using Microsoft.EntityFrameworkCore;
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
    public class PickListMasterService :IPickListMasterService
    {
        private readonly IPickListMasterRepository _pickListMasterRepository;
        public PickListMasterService(IPickListMasterRepository pickListMasterRepository)
        {
            _pickListMasterRepository = pickListMasterRepository;
        }

        public async Task DeleteAsync(PickListMaster user)
        {
            await _pickListMasterRepository.DeleteAsync(user);
        }

        public async Task<PickListMaster> DetailsAsync(int id)
        {
            return await _pickListMasterRepository.DetailsAsync(id);
        }

        public  IEnumerable<PickListMaster> GetPickListMasterList()
        {
            return _pickListMasterRepository.GetPickListTypes();
        }

        public IEnumerable<PickListMaster> GetPickListMasterList(string type)
        {
            return _pickListMasterRepository.GetPickListTypes(type);
        }

        public async Task InsertAsync(PickListMaster user)
        {
           await _pickListMasterRepository.InsertAsync(user);
        }

        public async Task<bool> UpdateAsync(PickListMaster user)
        {
            return await _pickListMasterRepository.UpdateAsync(user);
        }
    }
}
