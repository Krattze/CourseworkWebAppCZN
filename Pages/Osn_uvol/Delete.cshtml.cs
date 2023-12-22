using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppCZN.Data;

namespace WebAppCZN.Pages.Osn_uvol
{
    public class DeleteModel : PageModel
    {
        private readonly WebAppCZN.Data.ApplicationDbContext _context;

        public DeleteModel(WebAppCZN.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Основания_увольнения Основания_увольнения { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var основания_увольнения = await _context.Основания_увольнения.FirstOrDefaultAsync(m => m.ID_основания_увольнения == id);

            if (основания_увольнения == null)
            {
                return NotFound();
            }
            else
            {
                Основания_увольнения = основания_увольнения;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var основания_увольнения = await _context.Основания_увольнения.FindAsync(id);
            if (основания_увольнения != null)
            {
                Основания_увольнения = основания_увольнения;
                _context.Основания_увольнения.Remove(Основания_увольнения);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
