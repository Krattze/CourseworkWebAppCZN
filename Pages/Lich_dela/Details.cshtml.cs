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

namespace WebAppCZN.Pages.Lich_dela
{
    [Authorize(Roles = "Инспектор,Админ,РосТруд")]
    public class DetailsModel : PageModel
    {
        private readonly WebAppCZN.Data.ApplicationDbContext _context;

        public DetailsModel(WebAppCZN.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Личные_дела Личные_дела { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var личные_дела = await _context.Личные_дела.FirstOrDefaultAsync(m => m.ID_личного_дела == id);
            if (личные_дела == null)
            {
                return NotFound();
            }
            else
            {
                Личные_дела = личные_дела;
            }
            return Page();
        }
    }
}
