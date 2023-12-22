using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppCZN.Data;

namespace WebAppCZN.Pages.Rezume
{
    public class IndexModel : PageModel
    {
        private readonly WebAppCZN.Data.ApplicationDbContext _context;

        public IndexModel(WebAppCZN.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Резюме> Резюме { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Резюме = await _context.Резюме
                .Include(р => р.График_Работы)
                .Include(р => р.Заявление)
                .Include(р => р.Тип_Занятости).ToListAsync();
        }
    }
}
