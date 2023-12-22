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
using WebAppCZN.Data;
using WebAppCZN.Data.BD;

namespace WebAppCZN.Pages.Vak
{
    [Authorize(Roles = "Админ,Работодатель")]
    public class CreateModel : PageModel
    {
        private readonly WebAppCZN.Data.ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> userManager;
        public CreateModel(WebAppCZN.Data.ApplicationDbContext context, UserManager<IdentityUser> UserManager)
        {
            _context = context;
            userManager = UserManager;
        }

        public IActionResult OnGet()
        {
        ViewData["ID_формы_занятости"] = new SelectList(_context.График_работы, "ID_формы_занятости", "Форма_занятости");
        ViewData["ID_образования"] = new SelectList(_context.Образование, "Id_образования", "Образования");
        ViewData["ID_организации"] = new SelectList(_context.Организации, "ID_организации", "Наименование");
        ViewData["ID_тип_занятости"] = new SelectList(_context.Тип_занятости, "ID_тип_занятости", "Тип_Занятости");
            return Page();
        }
        public Audit Audit { get; set; }
        [BindProperty]
        public Вакансии Вакансии { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Вакансии.Add(Вакансии);
            await _context.SaveChangesAsync();
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userManager.FindByIdAsync(userID);
            string userEmail = await userManager.GetEmailAsync(user);
            Audit aud = new Audit
            {
                date = DateTime.Now,
                table_name = "Вакансии",
                operation = "Create",
                user_log = userEmail
            };

            _context.Audit.Add(aud);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
