using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppCZN.Data;
using WebAppCZN.Data.BD;

namespace WebAppCZN.Pages.Predl
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
            
            ViewData["ID_вакансии"] = new SelectList(_context.Вакансии, "ID_вакансии", "Профессия");
            ViewData["ID_личного_дела"] = new SelectList(_context.Личные_дела, "ID_личного_дела", "Дата_постановки_на_учет");
            ViewData["ID_резюме"] = new SelectList(_context.Резюме, "ID_резюме", "Желаемая_должность");
            return Page();
        }

        [BindProperty]
        public Предложенные_вакансии Предложенные_вакансии { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Предложенные_вакансии.Add(Предложенные_вакансии);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
