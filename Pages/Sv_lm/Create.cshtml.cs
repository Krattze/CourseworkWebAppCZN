using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppCZN.Data;
using Microsoft.AspNetCore.Authorization;

namespace WebAppCZN.Pages.Sv_lm
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
        ViewData["ID_заявления"] = new SelectList(_context.Заявления, "ID_заявления", "ID_заявления");
        ViewData["ID_основания_увольнения"] = new SelectList(_context.Основания_увольнения, "ID_основания_увольнения", "ID_основания_увольнения");
            return Page();
        }

        [BindProperty]
        public Сведения_о_последнем_месте_работы Сведения_о_последнем_месте_работы { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Сведения_о_последнем_месте_работы.Add(Сведения_о_последнем_месте_работы);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
