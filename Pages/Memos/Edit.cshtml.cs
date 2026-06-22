using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudApp.Data;
using CrudApp.Models;

namespace CrudApp.Pages_Memos
{
    public class EditModel : PageModel
    {
        private readonly CrudApp.Data.AppDbContext _context;

        public EditModel(CrudApp.Data.AppDbContext context)
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

            var memo =  await _context.Memos.FirstOrDefaultAsync(m => m.Id == id);
            if (memo == null)
            {
                return NotFound();
            }
            Memo = memo;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Memo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemoExists(Memo.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MemoExists(int id)
        {
            return _context.Memos.Any(e => e.Id == id);
        }
    }
}
