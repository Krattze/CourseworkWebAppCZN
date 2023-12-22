using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace WebAppCZN.Pages
{
    public class IndexModel1 : PageModel
    {
        private readonly ILogger<IndexModel1> _logger;

        public IndexModel1(ILogger<IndexModel1> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
