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

namespace WebAppCZN.Pages.Predl
{
    [Authorize(Roles = "Инспектор,Админ,РосТруд")]
    public class IndexModel : PageModel
    {
        private readonly WebAppCZN.Data.ApplicationDbContext _context;

        public IndexModel(WebAppCZN.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Предложенные_вакансии> Предложенные_вакансии { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Предложенные_вакансии = await _context.Предложенные_вакансии
                .Include(п => п.Вакансии)
                .Include(п => п.Личные_дела)
                .Include(п => п.Резюме).ToListAsync();
        }
    }
}
