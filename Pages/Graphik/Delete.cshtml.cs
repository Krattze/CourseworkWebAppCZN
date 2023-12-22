﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppCZN.Data;

namespace WebAppCZN.Pages.Graphik
{
    public class DeleteModel : PageModel
    {
        private readonly WebAppCZN.Data.ApplicationDbContext _context;

        public DeleteModel(WebAppCZN.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public График_работы График_работы { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var график_работы = await _context.График_работы.FirstOrDefaultAsync(m => m.ID_формы_занятости == id);

            if (график_работы == null)
            {
                return NotFound();
            }
            else
            {
                График_работы = график_работы;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var график_работы = await _context.График_работы.FindAsync(id);
            if (график_работы != null)
            {
                График_работы = график_работы;
                _context.График_работы.Remove(График_работы);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
