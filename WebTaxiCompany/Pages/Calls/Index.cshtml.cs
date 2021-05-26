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
    public class IndexModel : PageModel
    {
        private readonly WebTaxiCompany.Data.TaxiCompanyContext _context;

        public IndexModel(WebTaxiCompany.Data.TaxiCompanyContext context)
        {
            _context = context;
        }

        public IList<Call> Call { get;set; }

        public async Task OnGetAsync()
        {
            Call = await _context.Call
                .Include(c => c.AddServiceKeyNavigation)
                .Include(c => c.CarKeyNavigation)
                .Include(c => c.EmployeeKeyNavigation)
                .Include(c => c.RateKeyNavigation).ToListAsync();
        }
    }
}
