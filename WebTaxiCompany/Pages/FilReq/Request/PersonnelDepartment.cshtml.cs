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
    public class PersonnelDepartmentModel : PageModel
    {
        private readonly WebTaxiCompany.Data.TaxiCompanyContext _context;

        public PersonnelDepartmentModel(WebTaxiCompany.Data.TaxiCompanyContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get; set; }
        public IList<Position> Position { get; set; }
        public async Task OnGetAsync()
        {
            Employee = await _context.Employee.ToListAsync();
            Position = await _context.Position.ToListAsync();
        }
    }
}