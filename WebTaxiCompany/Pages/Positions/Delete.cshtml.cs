using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebTaxiCompany.Data;
using WebTaxiCompany.Models;

namespace WebTaxiCompany.Pages.Positions
{
    public class DeleteModel : PageModel
    {
        private readonly WebTaxiCompany.Data.TaxiCompanyContext _context;

        public DeleteModel(WebTaxiCompany.Data.TaxiCompanyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Position Position { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Position = await _context.Position.FirstOrDefaultAsync(m => m.PositionKey == id);

            if (Position == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Position = await _context.Position.FindAsync(id);

            if (Position != null)
            {
                _context.Position.Remove(Position);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
