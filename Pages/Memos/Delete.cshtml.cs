using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CrudApp.Data;
using CrudApp.Models;

namespace CrudApp.Pages_Memos
{
    public class DeleteModel : PageModel
    {
        private readonly CrudApp.Data.AppDbContext _context;

        public DeleteModel(CrudApp.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Memo Memo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memo = await _context.Memos.FirstOrDefaultAsync(m => m.Id == id);

            if (memo == null)
            {
                return NotFound();
            }
            else
            {
                Memo = memo;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memo = await _context.Memos.FindAsync(id);
            if (memo != null)
            {
                Memo = memo;
                _context.Memos.Remove(Memo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
