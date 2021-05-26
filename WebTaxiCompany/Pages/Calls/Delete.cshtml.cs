using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebTaxiCompany.Data;
using WebTaxiCompany.Models;

namespace WebTaxiCompany.Pages.Calls
{
    public class DeleteModel : PageModel
    {
        private readonly WebTaxiCompany.Data.TaxiCompanyContext _context;

        public DeleteModel(WebTaxiCompany.Data.TaxiCompanyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Call Call { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Call = await _context.Call
                .Include(c => c.AddServiceKeyNavigation)
                .Include(c => c.CarKeyNavigation)
                .Include(c => c.EmployeeKeyNavigation)
                .Include(c => c.RateKeyNavigation).FirstOrDefaultAsync(m => m.NumKey == id);

            if (Call == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Call = await _context.Call.FindAsync(id);

            if (Call != null)
            {
                _context.Call.Remove(Call);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
