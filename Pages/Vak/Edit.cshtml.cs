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

namespace WebAppCZN.Pages.Vak
{
    [Authorize(Roles = "Админ,Работодатель")]
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
        public Вакансии Вакансии { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var вакансии =  await _context.Вакансии.FirstOrDefaultAsync(m => m.ID_вакансии == id);
            if (вакансии == null)
            {
                return NotFound();
            }
            Вакансии = вакансии;
            ViewData["ID_формы_занятости"] = new SelectList(_context.График_работы, "ID_формы_занятости", "Форма_занятости");
            ViewData["ID_образования"] = new SelectList(_context.Образование, "Id_образования", "Образования");
            ViewData["ID_организации"] = new SelectList(_context.Организации, "ID_организации", "Наименование");
            ViewData["ID_тип_занятости"] = new SelectList(_context.Тип_занятости, "ID_тип_занятости", "Тип_Занятости");
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

            _context.Attach(Вакансии).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = await userManager.FindByIdAsync(userID);
                string userEmail = await userManager.GetEmailAsync(user);
                Audit aud = new Audit
                {
                    date = DateTime.Now,
                    table_name = "Вакансии",
                    operation = "Update",
                    user_log = userEmail
                };

                _context.Audit.Add(aud);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ВакансииExists(Вакансии.ID_вакансии))
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

        private bool ВакансииExists(int id)
        {
            return _context.Вакансии.Any(e => e.ID_вакансии == id);
        }
    }
}
