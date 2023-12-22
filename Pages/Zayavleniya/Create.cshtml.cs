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

namespace WebAppCZN.Pages.Zayavleniya
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
            return Page();
        }

		[BindProperty]
		public Сведения_о_последнем_месте_работы Сведения_о_последнем_месте_работы { get; set; } = default!;

		[BindProperty]
		public Заявление Заявление { get; set; } = default!;
	
		[BindProperty]
		public Личные_данные Личные_данные { get; set; } = default!;

		// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
		public async Task<IActionResult> OnPostAsync(int selectedResumeId)
        {
			var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //Заявление.ID_пользователя = userID;
            Заявление.Дата_подачи = DateTime.Now;
			bool isChecked_st = Request.Form["Заявление.Признание_безработным"] == "on";
            Заявление.Признание_безработным = isChecked_st;
			bool isChecked_op = Request.Form["isChecked"] == "true";
			_context.Заявления.Add(Заявление);
			await _context.SaveChangesAsync();
            if (isChecked_op)
            {
                Сведения_о_последнем_месте_работы.ID_заявления = Заявление.ID_заявления;
				_context.Сведения_о_последнем_месте_работы.Add(Сведения_о_последнем_месте_работы);
				await _context.SaveChangesAsync();
			}

			var rez = await _context.Резюме.FirstOrDefaultAsync(m => m.ID_резюме == selectedResumeId);
			if(rez != null)
			{
				rez.ID_заявления = Заявление.ID_заявления;
			}
			

			await _context.SaveChangesAsync();
			if (!ModelState.IsValid)
			{
				return Page();
			}



			return RedirectToPage("~/");
        }
    }
}
