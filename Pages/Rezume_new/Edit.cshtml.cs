using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppCZN.Data;
using Microsoft.AspNetCore.Authorization;

namespace WebAppCZN.Pages.Rezume_new
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
        public Резюме Резюме { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var резюме =  await _context.Резюме.FirstOrDefaultAsync(m => m.ID_резюме == id);
            if (резюме == null)
            {
                return NotFound();
            }
            Резюме = резюме;
           ViewData["ID_формы_занятости"] = new SelectList(_context.График_работы, "ID_формы_занятости", "Форма_занятости");
           ViewData["ID_заявления"] = new SelectList(_context.Заявления, "ID_заявления", "Дата_подачи");
           ViewData["ID_тип_занятости"] = new SelectList(_context.Тип_занятости, "ID_тип_занятости", "Тип_Занятости");
            ViewData["ID_Личных_данных"] = new SelectList(_context.Личные_данные, "ID_личных_данных", "Фамилия");
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

            _context.Attach(Резюме).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!РезюмеExists(Резюме.ID_резюме))
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

        private bool РезюмеExists(int id)
        {
            return _context.Резюме.Any(e => e.ID_резюме == id);
        }
    }
}
