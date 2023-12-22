using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppCZN.Data;

namespace WebAppCZN.Pages.Opyt_new
{
    [Authorize(Roles = "Инспектор,Админ")]
    public class DetailsModel : PageModel
    {
        private readonly WebAppCZN.Data.ApplicationDbContext _context;

        public DetailsModel(WebAppCZN.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Опыт_работы Опыт_работы { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var опыт_работы = await _context.Опыт_работы.FirstOrDefaultAsync(m => m.ID_опыта_работы == id);
            if (опыт_работы == null)
            {
                return NotFound();
            }
            else
            {
                Опыт_работы = опыт_работы;
            }
            return Page();
        }
    }
}
