using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSABanking.DataAccess.Models;

namespace TSABanking.Services.Interfaces
{
    public interface IPickListMasterService
    {
        IEnumerable<PickListMaster> GetPickListMasterList();
        Task<bool> UpdateAsync(PickListMaster user);
        Task InsertAsync(PickListMaster user);
        Task DeleteAsync(PickListMaster user);
        Task<PickListMaster> DetailsAsync(int id);
        IEnumerable<PickListMaster> GetPickListMasterList(string type);
    }
}
