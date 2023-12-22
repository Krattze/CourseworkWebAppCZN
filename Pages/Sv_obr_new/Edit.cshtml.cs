using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppCZN.Data;
using WebAppCZN.Data.BD;
using Microsoft.AspNetCore.Authorization;
namespace WebAppCZN.Pages.Sv_obr_new
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
        public Сведения_об_образовании Сведения_об_образовании { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var сведения_об_образовании =  await _context.Сведения_об_образовании.FirstOrDefaultAsync(m => m.ID_сведения_об_образовании == id);
            if (сведения_об_образовании == null)
            {
                return NotFound();
            }
            Сведения_об_образовании = сведения_об_образовании;
           ViewData["ID_образования"] = new SelectList(_context.Образование, "Id_образования", "Образования");
           ViewData["ID_резюме"] = new SelectList(_context.Резюме, "ID_резюме", "Желаемая_должность");
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

            _context.Attach(Сведения_об_образовании).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Сведения_об_образованииExists(Сведения_об_образовании.ID_сведения_об_образовании))
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

        private bool Сведения_об_образованииExists(int id)
        {
            return _context.Сведения_об_образовании.Any(e => e.ID_сведения_об_образовании == id);
        }
    }
}
