using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppCZN.Data;
using WebAppCZN.Data.BD;
using Microsoft.AspNetCore.Authorization;
namespace WebAppCZN.Pages.Sv_obr_new
{
    [Authorize(Roles = "Инспектор,Админ")]
    public class IndexModel : PageModel
    {
        private readonly WebAppCZN.Data.ApplicationDbContext _context;

        public IndexModel(WebAppCZN.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Сведения_об_образовании> Сведения_об_образовании { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Сведения_об_образовании = await _context.Сведения_об_образовании
                .Include(с => с.Образование)
                .Include(с => с.Резюме).ToListAsync();
        }
    }
}
