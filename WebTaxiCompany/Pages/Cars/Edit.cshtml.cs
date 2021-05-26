using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebTaxiCompany.Data;
using WebTaxiCompany.Models;

namespace WebTaxiCompany.Pages.Cars
{
    public class EditModel : PageModel
    {
        private readonly WebTaxiCompany.Data.TaxiCompanyContext _context;

        public EditModel(WebTaxiCompany.Data.TaxiCompanyContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["BrandKey"] = new SelectList(_context.Brand, "BrandKey", "Name");
           ViewData["EmployeeKey"] = new SelectList(_context.Employee, "EmployeeKey", "Address");
           ViewData["MechanicKeyEmployeeKey"] = new SelectList(_context.Employee, "EmployeeKey", "Address");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(Car.CarKey))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CarExists(long id)
        {
            return _context.Car.Any(e => e.CarKey == id);
        }
    }
}
