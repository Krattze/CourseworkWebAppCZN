using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppCZN.Data;

namespace WebAppCZN.Pages.Opyt
{
    public class CreateModel : PageModel
    {
        private readonly WebAppCZN.Data.ApplicationDbContext _context;

        public CreateModel(WebAppCZN.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ID_резюме"] = new SelectList(_context.Резюме, "ID_резюме", "Адрес_места_жительства");
            return Page();
        }

        [BindProperty]
        public Опыт_работы Опыт_работы { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Опыт_работы.Add(Опыт_работы);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
