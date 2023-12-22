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

namespace WebAppCZN.Pages.Tip
{
    [Authorize(Roles = "Админ")]
    public class CreateModel : PageModel
    {
        private readonly WebAppCZN.Data.ApplicationDbContext _context;

        public CreateModel(WebAppCZN.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Тип_занятости Тип_занятости { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Тип_занятости.Add(Тип_занятости);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
