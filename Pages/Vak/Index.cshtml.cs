using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebAppCZN.Data;
using WebAppCZN.Data.BD;

namespace WebAppCZN.Pages.Vak
{ 

    [Authorize(Roles = "Инспектор,Админ,Работодатель,РосТруд")]
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
        public IList<Вакансии> Вакансии { get;set; } = default!;

        public async Task OnGetAsync(string sortOrder, string searchTerm, string currentSortOrder)
        {

            var resumes = _context.Вакансии
                .Include(в => в.График_Работы)
                .Include(в => в.Образование)
                .Include(в => в.Организации)
                .Include(в => в.Тип_Занятости).AsQueryable();

            if (sortOrder != null)
            {
                sortOrder = sortOrder.Trim();
            }

            ViewData["Prof"] = sortOrder == "Prof" ? "Prof_desc" : "Prof";
            ViewData["ZP"] = sortOrder == "ZP" ? "ZP_desc" : "ZP";
            ViewData["AD"] = sortOrder == "AD" ? "AD_desc" : "AD";
            ViewData["DYA"] = sortOrder == "DYA" ? "DYA_desc" : "DYA";
            ViewData["GR"] = sortOrder == "GR" ? "GR_desc" : "GR";
            ViewData["Tip"] = sortOrder == "Tip" ? "Tip_desc" : "Tip";
            ViewData["Obr"] = sortOrder == "Obr" ? "Obr_desc" : "Obr";
            ViewData["ST"] = sortOrder == "ST" ? "ST_desc" : "ST";
            ViewData["Org"] = sortOrder == "Org" ? "Org_desc" : "Org";
            // Получите резюме из базы данных на основе поискового запроса


            if (!String.IsNullOrEmpty(searchTerm))
            {
                resumes = resumes.Where(r =>
                    r.Профессия.Contains(searchTerm) ||
                    r.Адрес_трудоустройства.Contains(searchTerm) ||
                    r.Должностные_обязанности.Contains(searchTerm) ||
                    r.Образование.Образования.Contains(searchTerm) ||
                    r.Организации.Наименование.Contains(searchTerm) ||
                    r.График_Работы.Форма_занятости.Contains(searchTerm) ||
                    r.Тип_Занятости.Тип_Занятости.Contains(searchTerm)
                );
            }
            bool isDesc = sortOrder == $"{currentSortOrder}_desc";

            switch (currentSortOrder)
            {
                case "Prof":
                    resumes = isDesc ? resumes.OrderByDescending(r => r.Профессия) : resumes.OrderBy(r => r.Профессия);
                    break;
                case "ZP":
                    resumes = isDesc ? resumes.OrderByDescending(r => r.Зарплата) : resumes.OrderBy(r => r.Зарплата);
                    break;
                case "DYA":
                    resumes = isDesc ? resumes.OrderByDescending(r => r.Должностные_обязанности) : resumes.OrderBy(r => r.Должностные_обязанности);
                    break;

                case "AD":
                    resumes = isDesc ? resumes.OrderByDescending(r => r.Адрес_трудоустройства) : resumes.OrderBy(r => r.Адрес_трудоустройства);
                    break;
                case "Obr":
                    resumes = isDesc ? resumes.OrderByDescending(r => r.Образование.Образования) : resumes.OrderBy(r => r.Образование.Образования);
                    break;
                case "ST":
                    resumes = isDesc ? resumes.OrderByDescending(r => r.Стаж) : resumes.OrderBy(r => r.Стаж);
                    break;
                case "GR":
                    resumes = isDesc ? resumes.OrderByDescending(r => r.График_Работы.Форма_занятости) : resumes.OrderBy(r => r.График_Работы.Форма_занятости);
                    break;
                case "Tip":
                    resumes = isDesc ? resumes.OrderByDescending(r => r.Тип_Занятости.Тип_Занятости) : resumes.OrderBy(r => r.Тип_Занятости.Тип_Занятости);
                    break;
                case "Org":
                    resumes = isDesc ? resumes.OrderByDescending(r => r.Организации.Наименование) : resumes.OrderBy(r => r.Организации.Наименование);
                    break;
                default:
                    resumes = resumes.OrderBy(r => r.Профессия);
                    break;
            }
            if (currentSortOrder != null)
            {
                ViewData[currentSortOrder] = isDesc ? $"{currentSortOrder}" : $"{currentSortOrder}_desc";
            }

            Вакансии = await resumes.ToListAsync();
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userManager.FindByIdAsync(userID);
            string userEmail = await userManager.GetEmailAsync(user);
            Audit aud = new Audit
            {
                date = DateTime.Now,
                table_name = "Вакансии",
                operation = "Select",
                user_log = userEmail
            };

            _context.Audit.Add(aud);
            await _context.SaveChangesAsync();
        }
    }
}
