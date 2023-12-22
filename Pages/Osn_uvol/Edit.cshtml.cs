using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppCZN.Data;

namespace WebAppCZN.Pages.Osn_uvol
{
    [Authorize(Roles = "Админ")]
    public class EditModel : PageModel
    {
        private readonly WebAppCZN.Data.ApplicationDbContext _context;

        public EditModel(WebAppCZN.Data.ApplicationDbContext context)
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

            var основания_увольнения =  await _context.Основания_увольнения.FirstOrDefaultAsync(m => m.ID_основания_увольнения == id);
            if (основания_увольнения == null)
            {
                return NotFound();
            }
            Основания_увольнения = основания_увольнения;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Основания_увольнения).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Основания_увольненияExists(Основания_увольнения.ID_основания_увольнения))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool Основания_увольненияExists(int id)
        {
            return _context.Основания_увольнения.Any(e => e.ID_основания_увольнения == id);
        }
    }
}
