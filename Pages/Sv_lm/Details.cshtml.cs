using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppCZN.Data;
using Microsoft.AspNetCore.Authorization;
namespace WebAppCZN.Pages.Sv_lm
{

    [Authorize(Roles = "Инспектор,Админ")]
    public class DetailsModel : PageModel
    {
        private readonly WebAppCZN.Data.ApplicationDbContext _context;

        public DetailsModel(WebAppCZN.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Сведения_о_последнем_месте_работы Сведения_о_последнем_месте_работы { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var сведения_о_последнем_месте_работы = await _context.Сведения_о_последнем_месте_работы.FirstOrDefaultAsync(m => m.ID_сведения == id);
            if (сведения_о_последнем_месте_работы == null)
            {
                return NotFound();
            }
            else
            {
                Сведения_о_последнем_месте_работы = сведения_о_последнем_месте_работы;
            }
            return Page();
        }
    }
}
