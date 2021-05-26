using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebTaxiCompany.Data;
using WebTaxiCompany.Models;

namespace WebTaxiCompany.Pages.Rates
{
    public class DeleteModel : PageModel
    {
        private readonly WebTaxiCompany.Data.TaxiCompanyContext _context;

        public DeleteModel(WebTaxiCompany.Data.TaxiCompanyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Rate Rate { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Rate = await _context.Rate.FirstOrDefaultAsync(m => m.RateKey == id);

            if (Rate == null)
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

            Rate = await _context.Rate.FindAsync(id);

            if (Rate != null)
            {
                _context.Rate.Remove(Rate);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
