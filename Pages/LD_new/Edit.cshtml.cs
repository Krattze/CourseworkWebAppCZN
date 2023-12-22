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

namespace WebAppCZN.Pages.LD_new
{
    [Authorize(Roles = "Инспектор,Админ")]
    public class EditModel : PageModel
    {
        private readonly WebAppCZN.Data.ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> userManager;
        public EditModel(WebAppCZN.Data.ApplicationDbContext context, UserManager<IdentityUser> UserManager)
        {
            _context = context;
            userManager = UserManager;
        }

        public Audit Audit { get; set; }

        [BindProperty]
        public Личные_данные Личные_данные { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var личные_данные =  await _context.Личные_данные.FirstOrDefaultAsync(m => m.ID_личных_данных == id);
            if (личные_данные == null)
            {
                return NotFound();
            }
            Личные_данные = личные_данные;
           ViewData["ID_пола"] = new SelectList(_context.Пол, "ID_пола", "пол");
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

            _context.Attach(Личные_данные).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = await userManager.FindByIdAsync(userID);
                string userEmail = await userManager.GetEmailAsync(user);
                Audit aud = new Audit
                {
                    date = DateTime.Now,
                    table_name = "Личные данные",
                    operation = "Update",
                    user_log = userEmail
                };

                _context.Audit.Add(aud);
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

            return RedirectToPage("./Index");
        }

        private bool Личные_данныеExists(int id)
        {
            return _context.Личные_данные.Any(e => e.ID_личных_данных == id);
        }
    }
}
