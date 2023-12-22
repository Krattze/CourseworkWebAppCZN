using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppCZN.Data;

namespace WebAppCZN.Pages.Opyt
{
    public class DeleteModel : PageModel
    {
        private readonly WebAppCZN.Data.ApplicationDbContext _context;

        public DeleteModel(WebAppCZN.Data.ApplicationDbContext context)
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

            var опыт_работы = await _context.Опыт_работы.FirstOrDefaultAsync(m => m.ID_опыта_работы == id);

            if (опыт_работы == null)
            {
                return NotFound();
            }
            else
            {
                Опыт_работы = опыт_работы;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var опыт_работы = await _context.Опыт_работы.FindAsync(id);
            if (опыт_работы != null)
            {
                Опыт_работы = опыт_работы;
                _context.Опыт_работы.Remove(Опыт_работы);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
