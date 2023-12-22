using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppCZN.Data;

namespace WebAppCZN.Pages.Osn_uvol
{
    [Authorize(Roles = "Инспектор,Админ")]
    public class DetailsModel : PageModel
    {
        private readonly WebAppCZN.Data.ApplicationDbContext _context;

        public DetailsModel(WebAppCZN.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Основания_увольнения Основания_увольнения { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var основания_увольнения = await _context.Основания_увольнения.FirstOrDefaultAsync(m => m.ID_основания_увольнения == id);
            if (основания_увольнения == null)
            {
                return NotFound();
            }
            else
            {
                Основания_увольнения = основания_увольнения;
            }
            return Page();
        }
    }
}
