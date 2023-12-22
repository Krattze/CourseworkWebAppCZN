using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppCZN.Data;
using WebAppCZN.Data.BD;
using Microsoft.AspNetCore.Authorization;
namespace WebAppCZN.Pages.Sv_obr_new
{
    [Authorize(Roles = "Инспектор,Админ")]
    public class CreateModel : PageModel
    {
        private readonly WebAppCZN.Data.ApplicationDbContext _context;

        public CreateModel(WebAppCZN.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ID_образования"] = new SelectList(_context.Образование, "Id_образования", "Образования");
        ViewData["ID_резюме"] = new SelectList(_context.Резюме, "ID_резюме", "Желаемая_должность");
            return Page();
        }

        [BindProperty]
        public Сведения_об_образовании Сведения_об_образовании { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Сведения_об_образовании.Add(Сведения_об_образовании);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
