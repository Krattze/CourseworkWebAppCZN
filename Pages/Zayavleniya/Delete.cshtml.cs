using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppCZN.Data;
using WebAppCZN.Data.BD;

namespace WebAppCZN.Pages.Zayavleniya
{
    public class DeleteModel : PageModel
    {
        private readonly WebAppCZN.Data.ApplicationDbContext _context;

        public DeleteModel(WebAppCZN.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Заявление Заявление { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var заявление = await _context.Заявления.FirstOrDefaultAsync(m => m.ID_заявления == id);

            if (заявление == null)
            {
                return NotFound();
            }
            else
            {
                Заявление = заявление;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var заявление = await _context.Заявления.FindAsync(id);
            if (заявление != null)
            {
                Заявление = заявление;
                _context.Заявления.Remove(Заявление);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
