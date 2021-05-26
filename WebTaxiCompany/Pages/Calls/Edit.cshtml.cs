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

namespace WebTaxiCompany.Pages.Calls
{
    public class EditModel : PageModel
    {
        private readonly WebTaxiCompany.Data.TaxiCompanyContext _context;

        public EditModel(WebTaxiCompany.Data.TaxiCompanyContext context)
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
           ViewData["AddServiceKey"] = new SelectList(_context.AddService, "AddServiceKey", "Description");
           ViewData["CarKey"] = new SelectList(_context.Car, "CarKey", "SpecialMarks");
           ViewData["EmployeeKey"] = new SelectList(_context.Employee, "EmployeeKey", "Address");
           ViewData["RateKey"] = new SelectList(_context.Rate, "RateKey", "Description");
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

            _context.Attach(Call).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CallExists(Call.NumKey))
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

        private bool CallExists(int id)
        {
            return _context.Call.Any(e => e.NumKey == id);
        }
    }
}
