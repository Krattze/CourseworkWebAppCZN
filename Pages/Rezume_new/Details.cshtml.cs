using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppCZN.Data;
using Microsoft.AspNetCore.Authorization;
using WebAppCZN.Data.BD;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAppCZN.Pages.Rezume_new
{
    [Authorize(Roles = "Инспектор,Админ")]
    public class DetailsModel : PageModel
    {
        private readonly WebAppCZN.Data.ApplicationDbContext _context;

        public DetailsModel(WebAppCZN.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Резюме Резюме { get; set; } = default!;

        public Личные_данные Личные_данные { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var резюме = await _context.Резюме.FirstOrDefaultAsync(m => m.ID_резюме == id);
            резюме.График_Работы = await _context.График_работы.FirstOrDefaultAsync(m => m.ID_формы_занятости == резюме.ID_формы_занятости);
            резюме.Тип_Занятости = await _context.Тип_занятости.FirstOrDefaultAsync(m => m.ID_тип_занятости == резюме.ID_тип_занятости);

            var ld = await _context.Личные_данные.FirstOrDefaultAsync(m => m.ID_личных_данных == резюме.ID_Личных_данных);
            ld.Пол = await _context.Пол.FirstOrDefaultAsync(m => m.ID_пола == ld.ID_пола);
            ViewData["ID_формы_занятости"] = new SelectList(_context.График_работы, "ID_формы_занятости", "Форма_занятости");
            ViewData["ID_заявления"] = new SelectList(_context.Заявления, "ID_заявления", "Дата_подачи");
            ViewData["ID_тип_занятости"] = new SelectList(_context.Тип_занятости, "ID_тип_занятости", "Тип_Занятости");
            ViewData["ID_Личных_данных"] = new SelectList(_context.Тип_занятости, "ID_Личных_данных", "Фамилия");
            if (резюме == null)
            {
                return NotFound();
            }
            else
            {
                Личные_данные = ld;
                Резюме = резюме;
            }
            return Page();
        }
    }
}
