using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppCZN.Data;
using WebAppCZN.Data.BD;

namespace WebAppCZN.Pages.Predl
{
    public class DeleteModel : PageModel
    {
        private readonly WebAppCZN.Data.ApplicationDbContext _context;

        public DeleteModel(WebAppCZN.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Предложенные_вакансии Предложенные_вакансии { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var предложенные_вакансии = await _context.Предложенные_вакансии.FirstOrDefaultAsync(m => m.ID_предложения == id);

            if (предложенные_вакансии == null)
            {
                return NotFound();
            }
            else
            {
                Предложенные_вакансии = предложенные_вакансии;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var предложенные_вакансии = await _context.Предложенные_вакансии.FindAsync(id);
            if (предложенные_вакансии != null)
            {
                Предложенные_вакансии = предложенные_вакансии;
                _context.Предложенные_вакансии.Remove(Предложенные_вакансии);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
