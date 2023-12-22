using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppCZN.Data;

namespace WebAppCZN.Pages.Rezume
{
    public class DeleteModel : PageModel
    {
        private readonly WebAppCZN.Data.ApplicationDbContext _context;

        public DeleteModel(WebAppCZN.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Резюме Резюме { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var резюме = await _context.Резюме.FirstOrDefaultAsync(m => m.ID_резюме == id);

            if (резюме == null)
            {
                return NotFound();
            }
            else
            {
                Резюме = резюме;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var резюме = await _context.Резюме.FindAsync(id);
            if (резюме != null)
            {
                Резюме = резюме;
                _context.Резюме.Remove(Резюме);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
