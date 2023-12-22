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
    public class IndexModel : PageModel
    {
        private readonly WebAppCZN.Data.ApplicationDbContext _context;

        public IndexModel(WebAppCZN.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Личные_дела> Личные_дела { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Личные_дела = await _context.Личные_дела
                .Include(л => л.Заявление)
                .Include(л => л.Личные_данные).ToListAsync();
        }
    }
}
