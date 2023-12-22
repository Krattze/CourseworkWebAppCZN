using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppCZN.Data;
using WebAppCZN.Data.BD;

namespace WebAppCZN.Pages.Org
{

    [Authorize(Roles = "Инспектор,Админ,Работодатель,РосТруд")]
    public class DetailsModel : PageModel
    {
        private readonly WebAppCZN.Data.ApplicationDbContext _context;

        public DetailsModel(WebAppCZN.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Организации Организации { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var организации = await _context.Организации.FirstOrDefaultAsync(m => m.ID_организации == id);
            if (организации == null)
            {
                return NotFound();
            }
            else
            {
                Организации = организации;
            }
            return Page();
        }
    }
}
