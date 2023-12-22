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
    public class IndexModel : PageModel
    {
        private readonly WebAppCZN.Data.ApplicationDbContext _context;

        public IndexModel(WebAppCZN.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Основания_увольнения> Основания_увольнения { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Основания_увольнения = await _context.Основания_увольнения.ToListAsync();
        }
    }
}
