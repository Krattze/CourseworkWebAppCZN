using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppCZN.Data;
using WebAppCZN.Data.BD;

namespace WebAppCZN.Pages.LD
{
    public class CreateModel : PageModel
    {
        public readonly WebAppCZN.Data.ApplicationDbContext _context;

        public CreateModel(WebAppCZN.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ID_пола"] = new SelectList(_context.Set<Пол>(), "ID_пола", "пол");
            return Page();
        }

        [BindProperty]
        public Личные_данные Личные_данные { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {

                return Page();
            }

            _context.Личные_данные.Add(Личные_данные);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
