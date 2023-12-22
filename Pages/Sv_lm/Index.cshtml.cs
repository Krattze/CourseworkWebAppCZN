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
    public class IndexModel : PageModel
    {
        private readonly WebAppCZN.Data.ApplicationDbContext _context;

        public IndexModel(WebAppCZN.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Сведения_о_последнем_месте_работы> Сведения_о_последнем_месте_работы { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Сведения_о_последнем_месте_работы = await _context.Сведения_о_последнем_месте_работы
                .Include(с => с.Заявление)
                .Include(с => с.Основание_увольнения).ToListAsync();
        }
    }
}
