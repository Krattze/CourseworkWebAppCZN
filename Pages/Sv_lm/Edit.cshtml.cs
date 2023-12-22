using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppCZN.Data;
using Microsoft.AspNetCore.Authorization;
namespace WebAppCZN.Pages.Sv_lm
{

    [Authorize(Roles = "Инспектор,Админ")]
    public class EditModel : PageModel
    {
        private readonly WebAppCZN.Data.ApplicationDbContext _context;

        public EditModel(WebAppCZN.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Сведения_о_последнем_месте_работы Сведения_о_последнем_месте_работы { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var сведения_о_последнем_месте_работы =  await _context.Сведения_о_последнем_месте_работы.FirstOrDefaultAsync(m => m.ID_сведения == id);
            if (сведения_о_последнем_месте_работы == null)
            {
                return NotFound();
            }
            Сведения_о_последнем_месте_работы = сведения_о_последнем_месте_работы;
           ViewData["ID_заявления"] = new SelectList(_context.Заявления, "ID_заявления", "ID_заявления");
           ViewData["ID_основания_увольнения"] = new SelectList(_context.Основания_увольнения, "ID_основания_увольнения", "ID_основания_увольнения");
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

            _context.Attach(Сведения_о_последнем_месте_работы).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Сведения_о_последнем_месте_работыExists(Сведения_о_последнем_месте_работы.ID_сведения))
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

        private bool Сведения_о_последнем_месте_работыExists(int id)
        {
            return _context.Сведения_о_последнем_месте_работы.Any(e => e.ID_сведения == id);
        }
    }
}
