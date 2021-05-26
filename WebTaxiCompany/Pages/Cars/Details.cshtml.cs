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
    public class DetailsModel : PageModel
    {
        private readonly WebTaxiCompany.Data.TaxiCompanyContext _context;

        public DetailsModel(WebTaxiCompany.Data.TaxiCompanyContext context)
        {
            _context = context;
        }

        public Car Car { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _context.Car
                .Include(c => c.BrandKeyNavigation)
                .Include(c => c.EmployeeKeyNavigation)
                .Include(c => c.MechanicKeyEmployeeKeyNavigation).FirstOrDefaultAsync(m => m.CarKey == id);

            if (Car == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
