using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppCZN.Data;
using WebAppCZN.Data.BD;

namespace WebAppCZN.Pages.Sv_obr
{
    public class DetailsModel : PageModel
    {
        private readonly WebAppCZN.Data.ApplicationDbContext _context;

        public DetailsModel(WebAppCZN.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Сведения_об_образовании Сведения_об_образовании { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var сведения_об_образовании = await _context.Сведения_об_образовании.FirstOrDefaultAsync(m => m.ID_сведения_об_образовании == id);
            if (сведения_об_образовании == null)
            {
                return NotFound();
            }
            else
            {
                Сведения_об_образовании = сведения_об_образовании;
            }
            return Page();
        }
    }
}
