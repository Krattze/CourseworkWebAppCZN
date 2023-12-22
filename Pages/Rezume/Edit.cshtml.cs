using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppCZN.Data;
using WebAppCZN.Data.BD;

namespace WebAppCZN.Pages.Rezume
{
    public class EditModel : PageModel
    {
        private readonly WebAppCZN.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> userManager;

        public EditModel(WebAppCZN.Data.ApplicationDbContext context, UserManager<IdentityUser> UserManager)
        {
            _context = context;
            userManager = UserManager;
        }

        [BindProperty]
        public Резюме Резюме { get; set; } = default!;
        public Audit Audit { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var резюме =  await _context.Резюме.FirstOrDefaultAsync(m => m.ID_резюме == id);
            if (резюме == null)
            {
                return NotFound();
            }
            Резюме = резюме;
           ViewData["ID_формы_занятости"] = new SelectList(_context.График_работы, "ID_формы_занятости", "ID_формы_занятости");
           ViewData["ID_заявления"] = new SelectList(_context.Заявления, "ID_заявления", "ID_заявления");
           ViewData["ID_тип_занятости"] = new SelectList(_context.Тип_занятости, "ID_тип_занятости", "ID_тип_занятости");
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

            _context.Attach(Резюме).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = await userManager.FindByIdAsync(userID);
                string userEmail = await userManager.GetEmailAsync(user);
                Audit aud = new Audit
                {
                    date = DateTime.Now,
                    table_name = "Резюме",
                    operation = "Update",
                    user_log = userEmail
                };

                _context.Audit.Add(aud);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!РезюмеExists(Резюме.ID_резюме))
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

        private bool РезюмеExists(int id)
        {
            return _context.Резюме.Any(e => e.ID_резюме == id);
        }
    }
}
