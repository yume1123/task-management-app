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
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Memo> Memo { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Memo = await _context.Memos
                    .OrderByDescending(x => x.CreatedAt)
                    .ToListAsync();
        }

        public async Task<IActionResult> OnPostToggleAsync(int id)
        {
        var memo = await _context.Memos.FindAsync(id);

        if (memo != null)
        {
            if (!memo.IsCompleted)
            {
                memo.IsCompleted = true;
            }
            else
            {
                _context.Memos.Remove(memo);
            }

            await _context.SaveChangesAsync();
        }

        return RedirectToPage();
        }
    }
}