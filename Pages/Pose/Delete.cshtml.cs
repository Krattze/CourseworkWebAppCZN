using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppCZN.Data;
using WebAppCZN.Data.BD;

namespace WebAppCZN.Pages.Pose
{
    public class DeleteModel : PageModel
    {
        private readonly WebAppCZN.Data.ApplicationDbContext _context;

        public DeleteModel(WebAppCZN.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Посещения Посещения { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var посещения = await _context.Посещения.FirstOrDefaultAsync(m => m.ID_посещения == id);

            if (посещения == null)
            {
                return NotFound();
            }
            else
            {
                Посещения = посещения;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var посещения = await _context.Посещения.FindAsync(id);
            if (посещения != null)
            {
                Посещения = посещения;
                _context.Посещения.Remove(Посещения);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
