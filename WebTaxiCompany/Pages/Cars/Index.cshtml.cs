using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebTaxiCompany.Data;
using WebTaxiCompany.Models;

namespace WebTaxiCompany.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly WebTaxiCompany.Data.TaxiCompanyContext _context;

        public IndexModel(WebTaxiCompany.Data.TaxiCompanyContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get;set; }

        public async Task OnGetAsync()
        {
            Car = await _context.Car
                .Include(c => c.BrandKeyNavigation)
                .Include(c => c.EmployeeKeyNavigation)
                .Include(c => c.MechanicKeyEmployeeKeyNavigation).ToListAsync();
        }
    }
}
