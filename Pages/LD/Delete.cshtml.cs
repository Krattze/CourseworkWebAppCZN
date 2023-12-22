using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppCZN.Data;
using WebAppCZN.Data.BD;

namespace WebAppCZN.Pages.LD
{
    public class DeleteModel : PageModel
    {
        private readonly WebAppCZN.Data.ApplicationDbContext _context;

        public DeleteModel(WebAppCZN.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Личные_данные Личные_данные { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var личные_данные = await _context.Личные_данные.FirstOrDefaultAsync(m => m.ID_личных_данных == id);

            if (личные_данные == null)
            {
                return NotFound();
            }
            else
            {
                Личные_данные = личные_данные;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var личные_данные = await _context.Личные_данные.FindAsync(id);
            if (личные_данные != null)
            {
                Личные_данные = личные_данные;
                _context.Личные_данные.Remove(Личные_данные);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
