using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebTaxiCompany.Data;
using WebTaxiCompany.Models;

namespace WebTaxiCompany.Pages.FilReq.Request
{
    public class AutoparkModel : PageModel
    {
        private readonly WebTaxiCompany.Data.TaxiCompanyContext _context;

        public AutoparkModel(WebTaxiCompany.Data.TaxiCompanyContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get; set; }
        public IList<Brand> Brand { get; set; }
        public IList<Employee> Employee { get; set; }
        public async Task OnGetAsync()
        {
            Car = await _context.Car.ToListAsync();
            Brand = await _context.Brand.ToListAsync();
            Employee = await _context.Employee.ToListAsync();
        }
    }
}