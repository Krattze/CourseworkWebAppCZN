using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppCZN.Data;
using WebAppCZN.Data.BD;

namespace WebAppCZN.Pages.LD_new
{
    [Authorize(Roles = "Инспектор,Админ,РосТруд")]
    public class IndexModel : PageModel
    {
        private readonly WebAppCZN.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> userManager;

        public IndexModel(WebAppCZN.Data.ApplicationDbContext context, UserManager<IdentityUser> UserManager)
        {
            _context = context;
            userManager = UserManager;
        }

        public Audit Audit { get; set; }
        public IList<Личные_данные> Личные_данные { get;set; } = default!;

        public async Task OnGetAsync(string sortOrder, string searchTerm, string currentSortOrder)
        {
            var resumes =  _context.Личные_данные
                .Include(л => л.Пол).AsQueryable();

            if (sortOrder != null)
            {
                sortOrder = sortOrder.Trim();
            }

            ViewData["Fa"] = sortOrder == "Fa" ? "Fa_desc" : "Fa";
            ViewData["Im"] = sortOrder == "Im" ? "Im_desc" : "Im";
            ViewData["Ot"] = sortOrder == "Ot" ? "Ot_desc" : "Ot";
            ViewData["Data"] = sortOrder == "Data" ? "Data_desc" : "Data";
            ViewData["Pol"] = sortOrder == "Pol" ? "Pol_desc" : "Pol;";
         
            // Получите резюме из базы данных на основе поискового запроса


            if (!String.IsNullOrEmpty(searchTerm))
            {
                resumes = resumes.Where(r =>
                    r.Фамилия.Contains(searchTerm) ||
                    r.Имя.Contains(searchTerm) ||
                    r.Отчество.Contains(searchTerm) ||
                    r.Кем_выдан_паспорт.Contains(searchTerm) ||
                    r.Адрес_регистрации.Contains(searchTerm) ||
                    r.Пол.пол.Contains(searchTerm) 
                    
                );
            }
            bool isDesc = sortOrder == $"{currentSortOrder}_desc";

            switch (currentSortOrder)
            {
                case "Fa":
                    resumes = isDesc ? resumes.OrderByDescending(r => r.Фамилия) : resumes.OrderBy(r => r.Фамилия);
                    break;
                case "Im":
                    resumes = isDesc ? resumes.OrderByDescending(r => r.Имя) : resumes.OrderBy(r => r.Имя);
                    break;
                case "Ot":
                    resumes = isDesc ? resumes.OrderByDescending(r => r.Отчество) : resumes.OrderBy(r => r.Отчество);
                    break;
                case "Data":
                    resumes = isDesc ? resumes.OrderByDescending(r => r.Дата_рождения) : resumes.OrderBy(r => r.Дата_рождения);
                    break;
                case "Pol":
                    resumes = isDesc ? resumes.OrderByDescending(r => r.Пол.пол) : resumes.OrderBy(r => r.Пол.пол);
                    break;
                 default:
                    resumes = resumes.OrderBy(r => r.Фамилия);
                    break;
            }
            if (currentSortOrder != null)
            {
                ViewData[currentSortOrder] = isDesc ? $"{currentSortOrder}" : $"{currentSortOrder}_desc";
            }

            Личные_данные = await resumes.ToListAsync();
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userManager.FindByIdAsync(userID);
            string userEmail = await userManager.GetEmailAsync(user);
            Audit aud = new Audit
            {
                date = DateTime.Now,
                table_name = "Личные данные",
                operation = "Select",
                user_log = userEmail
            };

            _context.Audit.Add(aud);
            await _context.SaveChangesAsync();
        }
    }
}
