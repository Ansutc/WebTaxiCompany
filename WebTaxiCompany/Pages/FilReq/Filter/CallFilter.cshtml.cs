using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebTaxiCompany.Data;
using WebTaxiCompany.Models;

namespace WebTaxiCompany.Pages.FilReq.Filter
{
    public class CallFilterModel : PageModel
    {
        private readonly WebTaxiCompany.Data.TaxiCompanyContext _context;

        public CallFilterModel(WebTaxiCompany.Data.TaxiCompanyContext context)
        {
            _context = context;
        }

        public IList<Call> Call { get; set; }
        public Rate Rate { get; set; }
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Rate = _context.Rate.First(m => m.RateKey == id);

            if (Rate == null)
            {
                return NotFound();
            }
            Call = await _context.Call
                .Include(e => e.RateKeyNavigation).Where(m => m.RateKey == Rate.RateKey).ToListAsync();
            return Page();
        }
    }
}