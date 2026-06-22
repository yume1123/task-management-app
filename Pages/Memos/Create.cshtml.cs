using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CrudApp.Data;
using CrudApp.Models;

namespace CrudApp.Pages_Memos
{
    public class CreateModel : PageModel
    {
        private readonly CrudApp.Data.AppDbContext _context;

        public CreateModel(CrudApp.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Memo Memo { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Memos.Add(Memo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
