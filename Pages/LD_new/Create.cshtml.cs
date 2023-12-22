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

namespace WebAppCZN.Pages.LD_new
{
    [Authorize(Roles = "Инспектор,Админ")]
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
        ViewData["ID_пола"] = new SelectList(_context.Пол, "ID_пола", "пол");
            return Page();
        }

        [BindProperty]
        public Личные_данные Личные_данные { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Личные_данные.Add(Личные_данные);
            await _context.SaveChangesAsync();
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userManager.FindByIdAsync(userID);
            string userEmail = await userManager.GetEmailAsync(user);
            Audit aud = new Audit
            {
                date = DateTime.Now,
                table_name = "Личные данные",
                operation = "Create",
                user_log = userEmail
            };

            return RedirectToPage("./Index");
        }
    }
}
