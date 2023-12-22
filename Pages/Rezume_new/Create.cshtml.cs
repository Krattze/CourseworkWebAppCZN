using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppCZN.Data;

namespace WebAppCZN.Pages.Rezume_new
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
            ViewData["ID_формы_занятости"] = new SelectList(_context.График_работы, "ID_формы_занятости", "Форма_занятости");
            ViewData["ID_заявления"] = new SelectList(_context.Заявления, "ID_заявления", "Дата_подачи");
            ViewData["ID_тип_занятости"] = new SelectList(_context.Тип_занятости, "ID_тип_занятости", "Тип_Занятости");
            ViewData["ID_Личных_данных"] = new SelectList(_context.Личные_данные, "ID_личных_данных", "Фамилия");
            return Page();
        }

        [BindProperty]
        public Резюме Резюме { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Резюме.Add(Резюме);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
