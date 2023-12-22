using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppCZN.Data;

namespace WebAppCZN.Pages.Opyt
{
    public class EditModel : PageModel
    {
        private readonly WebAppCZN.Data.ApplicationDbContext _context;

        public EditModel(WebAppCZN.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Опыт_работы Опыт_работы { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var опыт_работы =  await _context.Опыт_работы.FirstOrDefaultAsync(m => m.ID_опыта_работы == id);
            if (опыт_работы == null)
            {
                return NotFound();
            }
            Опыт_работы = опыт_работы;
           ViewData["ID_резюме"] = new SelectList(_context.Резюме, "ID_резюме", "Адрес_места_жительства");
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

            _context.Attach(Опыт_работы).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Опыт_работыExists(Опыт_работы.ID_опыта_работы))
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

        private bool Опыт_работыExists(int id)
        {
            return _context.Опыт_работы.Any(e => e.ID_опыта_работы == id);
        }
    }
}
