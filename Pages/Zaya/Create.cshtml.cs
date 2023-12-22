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
namespace WebAppCZN.Pages.Zaya
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
        ViewData["ID_личных_данных"] = new SelectList(_context.Личные_данные, "ID_личных_данных", "ID_личных_данных");
            return Page();
        }

        [BindProperty]
        public Заявление Заявление { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Заявления.Add(Заявление);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
