using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppCZN.Data.BD;


namespace WebAppCZN.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly WebAppCZN.Data.ApplicationDbContext _context;

        private readonly RoleManager<IdentityRole> roleManager;

        [BindProperty]

        public Посещения Посещения { get; set; } = default!;

        public IndexModel(ILogger<IndexModel> logger, WebAppCZN.Data.ApplicationDbContext context, RoleManager<IdentityRole> RoleManager)
        {
            _logger = logger;
            _context = context;
            roleManager = RoleManager;
        }

        public async Task<IActionResult> OnGet()
        {
            //string[] str = { "Инспектор", "Админ", "Работодатель", "РосТруд" };
           
            //foreach(string roleName in str)
            //{
            //    if (!await roleManager.RoleExistsAsync(roleName))
            //    {
            //        await roleManager.CreateAsync(new IdentityRole
            //        {
            //            Name = roleName,
            //            NormalizedName = roleName
            //        });
            //    }
            //}
            return Page() ;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

           // _context.Посещения.Add(Посещения);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public List<SelectListItem> GetTimeSlots()
        {
            var timeSlots = new List<SelectListItem>();
            DateTime startTime = DateTime.Today.AddHours(9); // 9:00 AM
            DateTime endTime = DateTime.Today.AddHours(16).AddMinutes(45); // 4:45 PM
            TimeSpan interval = TimeSpan.FromMinutes(15);

            while (startTime <= endTime)
            {
                timeSlots.Add(new SelectListItem
                {
                    Value = startTime.ToString("HH:mm"),
                    Text = startTime.ToString("HH:mm tt")
                });
                startTime = startTime.Add(interval);
            }

            return timeSlots;
        }
    }
}
