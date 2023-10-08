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
    public class PickListMasterRepository : IPickListMasterRepository
    {
        private readonly TsabankingContext _context;
        public PickListMasterRepository(TsabankingContext context)
        {
            _context = context;
        }
        public async Task DeleteAsync(PickListMaster user)
        {
            _context.PickListMasters.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<PickListMaster> DetailsAsync(int id)
        {
            return await _context.PickListMasters.FirstOrDefaultAsync(m => m.Id == id);
        }

        public IEnumerable<PickListMaster> GetPickListTypes()
        {
            return _context.PickListMasters.AsQueryable();
        }

        public IEnumerable<PickListMaster> GetPickListTypes(string type)
        {
            var pickListType = _context.PickListTypes.FirstOrDefault(d => d.Code == type);
            if (pickListType == null) { return null; }
            return _context.PickListMasters.Where(s => s.Type == pickListType.Id && s.Active).AsQueryable();
        }

        public async Task InsertAsync(PickListMaster user)
        {
            _context.PickListMasters.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(PickListMaster user)
        {
            _context.Attach(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PicklistMasterExists(user.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }
        private bool PicklistMasterExists(int id)
        {
            return (_context.PickListMasters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
