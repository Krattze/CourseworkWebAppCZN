using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppCZN.Data;
using WebAppCZN.Data.BD;

namespace WebAppCZN.Pages.LD
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly WebAppCZN.Data.ApplicationDbContext _context;

        public EditModel(SignInManager<IdentityUser> signInManager, WebAppCZN.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Личные_данные Личные_данные { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //if (userId == null)
            //{
            //    return NotFound();
            //}

            //var личные_данные =  await _context.Личные_данные.FirstOrDefaultAsync(m => m.ID_пользователя == userId);
            //if (личные_данные == null)
            //{
            //    return NotFound();
            //}
            //Личные_данные = личные_данные;

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Личные_данные.ID_пользователя = userId;

            _context.Attach(Личные_данные).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Личные_данныеExists(Личные_данные.ID_личных_данных))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Page();
        }

        private bool Личные_данныеExists(int id)
        {
            return _context.Личные_данные.Any(e => e.ID_личных_данных == id);
        }
    }
}
