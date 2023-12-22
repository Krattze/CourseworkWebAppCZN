using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppCZN.Data;
using WebAppCZN.Data.BD;

namespace WebAppCZN.Pages.Pol
{
    public class DeleteModel : PageModel
    {
        private readonly WebAppCZN.Data.ApplicationDbContext _context;

        public DeleteModel(WebAppCZN.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Пол Пол { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var пол = await _context.Пол.FirstOrDefaultAsync(m => m.ID_пола == id);

            if (пол == null)
            {
                return NotFound();
            }
            else
            {
                Пол = пол;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var пол = await _context.Пол.FindAsync(id);
            if (пол != null)
            {
                Пол = пол;
                _context.Пол.Remove(Пол);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
