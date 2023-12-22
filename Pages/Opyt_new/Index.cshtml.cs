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
    public class IndexModel : PageModel
    {
        private readonly WebAppCZN.Data.ApplicationDbContext _context;

        public IndexModel(WebAppCZN.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Опыт_работы> Опыт_работы { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Опыт_работы = await _context.Опыт_работы
                .Include(о => о.Резюме).ToListAsync();
        }
    }
}
