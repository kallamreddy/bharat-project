using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TSABanking.DataAccess.Models;
using TSABanking.Services;
using TSABanking.Services.Interfaces;

namespace TSABanking.Web.Pages.Banks
{
    public class DetailsModel : PageModel
    {
        private readonly IBankService _bankService;
        private readonly IUserService _userService;


        public DetailsModel(IBankService bankService, IUserService userService)
        {
            _bankService = bankService;
            _userService = userService;
        }

        public Bank Bank { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var users = _userService.GetUsers().Select(s => new
            {
                s.Id,
                Name = $"{s.FirstName} {s.MiddleInitial} {s.LastName}"
            });
            ViewData["UserId"] = new SelectList(users, "Id", "Name");
            if (id == null)
            {
                return NotFound();
            }

            var bank = await _bankService.DetailsAsync((int)id);
            if (bank == null)
            {
                return NotFound();
            }
            else 
            {
                foreach (var userBank in bank.UserBanks)
                {
                    var name = users.FirstOrDefault(d => d.Id == userBank.UserId).Name;
                    bank.SelectedUsers.Add(name);
                }
                Bank = bank;
            }
            return Page();
        }
    }
}
