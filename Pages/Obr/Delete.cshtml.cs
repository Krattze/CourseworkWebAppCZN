using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppCZN.Data;
using WebAppCZN.Data.BD;

namespace WebAppCZN.Pages.Obr
{
    public class DeleteModel : PageModel
    {
        private readonly WebAppCZN.Data.ApplicationDbContext _context;

        public DeleteModel(WebAppCZN.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Образование Образование { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var образование = await _context.Образование.FirstOrDefaultAsync(m => m.Id_образования == id);

            if (образование == null)
            {
                return NotFound();
            }
            else
            {
                Образование = образование;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var образование = await _context.Образование.FindAsync(id);
            if (образование != null)
            {
                Образование = образование;
                _context.Образование.Remove(Образование);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
