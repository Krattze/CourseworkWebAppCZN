using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppCZN.Data;
using WebAppCZN.Data.BD;

namespace WebAppCZN.Pages.Zayavleniya
{
    public class IndexModel : PageModel
    {
        private readonly WebAppCZN.Data.ApplicationDbContext _context;

        public IndexModel(WebAppCZN.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Заявление> Заявление { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Заявление = await _context.Заявления.ToListAsync();
        }
    }
}
