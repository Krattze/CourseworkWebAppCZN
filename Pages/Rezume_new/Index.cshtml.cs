using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppCZN.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient;

namespace WebAppCZN.Pages.Rezume_new
{
    [Authorize(Roles = "Инспектор,Админ")]
    public class IndexModel : PageModel
    {
        private readonly WebAppCZN.Data.ApplicationDbContext _context;

        public IndexModel(WebAppCZN.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Резюме> Резюме { get;set; } = default!;

        public async Task OnGetAsync(string sortOrder, string searchTerm, string currentSortOrder)
        {
            var resumes = _context.Резюме
        .Include(р => р.График_Работы)
        .Include(р => р.Заявление)
        .Include(р => р.Тип_Занятости).AsQueryable();
            if (sortOrder != null)
            {
                sortOrder = sortOrder.Trim();
            }
         
            ViewData["PositionSort"] = sortOrder == "Dolz" ? "Dolz_desc" : "Dolz";
            ViewData["Prof"] = sortOrder == "Prof" ? "Prof_desc" : "Prof";
            ViewData["Sf"] = sortOrder == "Sf" ? "Sf_desc" : "Sf";
            ViewData["ZP"] = sortOrder == "ZP" ? "ZP_desc" : "ZP";
            ViewData["AD"] = sortOrder == "AD" ? "AD_desc" : "AD";
            ViewData["DATA"] = sortOrder == "DATA" ? "DATA_desc" : "DATA";
            ViewData["GR"] = sortOrder == "GR" ? "GR_desc" : "GR";
            ViewData["Tip"] = sortOrder == "Tip" ? "Tip_desc" : "Tip";
            ViewData["LD"] = sortOrder == "LD" ? "LD_desc" : "LD";

            // Получите резюме из базы данных на основе поискового запроса

          
            if (!String.IsNullOrEmpty(searchTerm))
            {
                resumes = resumes.Where(r =>
                    r.Желаемая_должность.Contains(searchTerm) ||
                    r.Профессия.Contains(searchTerm)||
                    r.Адрес_места_жительства.Contains(searchTerm) ||
                    r.Профессия.Contains(searchTerm) ||
                    r.Сфера_деятельности.Contains(searchTerm) ||
                    r.График_Работы.Форма_занятости.Contains(searchTerm) ||
                    r.Тип_Занятости.Тип_Занятости.Contains(searchTerm)
                );
            }
            bool isDesc = sortOrder == $"{currentSortOrder}_desc";

            switch (currentSortOrder)
            {
                case "Dolz":
                    resumes = isDesc ? resumes.OrderByDescending(r => r.Желаемая_должность) : resumes.OrderBy(r => r.Желаемая_должность);
                    break;
                case "Prof":
                    resumes = isDesc ? resumes.OrderByDescending(r => r.Профессия) : resumes.OrderBy(r => r.Профессия);
                    break;
                case "Sf":
                    resumes = isDesc ? resumes.OrderByDescending(r => r.Сфера_деятельности) : resumes.OrderBy(r => r.Сфера_деятельности);
                    break;

                case "ZP":
                    resumes = isDesc ? resumes.OrderByDescending(r => r.Зарплата) : resumes.OrderBy(r => r.Зарплата);
                    break;
                case "DATA":
                    resumes = isDesc ? resumes.OrderByDescending(r => r.Дата_готовности_к_работе) : resumes.OrderBy(r => r.Дата_готовности_к_работе);
                    break;
                case "AD":
                    resumes = isDesc ? resumes.OrderByDescending(r => r.Адрес_места_жительства) : resumes.OrderBy(r => r.Адрес_места_жительства);
                    break;
                case "GR":
                    resumes = isDesc ? resumes.OrderByDescending(r => r.График_Работы.Форма_занятости) : resumes.OrderBy(r => r.График_Работы.Форма_занятости);
                    break;
                case "Tip":
                    resumes = isDesc ? resumes.OrderByDescending(r => r.Тип_Занятости.Тип_Занятости) : resumes.OrderBy(r => r.Тип_Занятости.Тип_Занятости);
                    break;
                default:
                    resumes = resumes.OrderBy(r => r.Желаемая_должность);
                    break;
            }
            if (currentSortOrder != null)
            {
                ViewData[currentSortOrder] = isDesc ? $"{currentSortOrder}" : $"{currentSortOrder}_desc";
            }
            Резюме = await resumes.ToListAsync();
        }
    }
    }

