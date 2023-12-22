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
using WebAppCZN.Data.BD;

namespace WebAppCZN.Pages.Predl
{
    [Authorize(Roles = "Инспектор,Админ")]
    public class EditModel : PageModel
    {
        private readonly WebAppCZN.Data.ApplicationDbContext _context;

        public EditModel(WebAppCZN.Data.ApplicationDbContext context)
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

            var предложенные_вакансии =  await _context.Предложенные_вакансии.FirstOrDefaultAsync(m => m.ID_предложения == id);
            if (предложенные_вакансии == null)
            {
                return NotFound();
            }
            Предложенные_вакансии = предложенные_вакансии;
           ViewData["ID_вакансии"] = new SelectList(_context.Вакансии, "ID_вакансии", "Адрес_трудоустройства");
           ViewData["ID_личного_дела"] = new SelectList(_context.Личные_дела, "ID_личного_дела", "ID_личного_дела");
           ViewData["ID_резюме"] = new SelectList(_context.Резюме, "ID_резюме", "Адрес_места_жительства");
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

            _context.Attach(Предложенные_вакансии).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Предложенные_вакансииExists(Предложенные_вакансии.ID_предложения))
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

        private bool Предложенные_вакансииExists(int id)
        {
            return _context.Предложенные_вакансии.Any(e => e.ID_предложения == id);
        }
    }
}
