using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppCZN.Data;
using WebAppCZN.Data.BD;

namespace WebAppCZN.Pages.Tip
{
    public class DeleteModel : PageModel
    {
        private readonly WebAppCZN.Data.ApplicationDbContext _context;

        public DeleteModel(WebAppCZN.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Тип_занятости Тип_занятости { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var тип_занятости = await _context.Тип_занятости.FirstOrDefaultAsync(m => m.ID_тип_занятости == id);

            if (тип_занятости == null)
            {
                return NotFound();
            }
            else
            {
                Тип_занятости = тип_занятости;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var тип_занятости = await _context.Тип_занятости.FindAsync(id);
            if (тип_занятости != null)
            {
                Тип_занятости = тип_занятости;
                _context.Тип_занятости.Remove(Тип_занятости);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
