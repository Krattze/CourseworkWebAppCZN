using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppCZN.Data;
using WebAppCZN.Data.BD;

namespace WebAppCZN.Pages.Rezume
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
        //ViewData["ID_формы_занятости"] = new SelectList(_context.График_работы, "ID_формы_занятости", "ID_формы_занятости");
        //ViewData["ID_заявления"] = new SelectList(_context.Заявления, "ID_заявления", "ID_заявления");
        //ViewData["ID_тип_занятости"] = new SelectList(_context.Тип_занятости, "ID_тип_занятости", "ID_тип_занятости");
            return Page();
        }

        [BindProperty]
        public Сведения_об_образовании Сведения_об_образовании { get; set; } = default!;
        [BindProperty]
        public Резюме Резюме { get; set; } = default!;
        [BindProperty]
        public Опыт_работы Опыт_работы { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
			var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
			//Резюме.ID_пользователя = userID;
			if (!ModelState.IsValid)
            {
                return Page();
            }
		

			_context.Резюме.Add(Резюме);
            await _context.SaveChangesAsync();

            Сведения_об_образовании.ID_резюме = Резюме.ID_резюме;
			_context.Сведения_об_образовании.Add(Сведения_об_образовании);

			Опыт_работы.ID_резюме = Резюме.ID_резюме;
			_context.Опыт_работы.Add(Опыт_работы);

			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
        }
    }
}
