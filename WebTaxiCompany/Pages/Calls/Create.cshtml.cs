using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebTaxiCompany.Data;
using WebTaxiCompany.Models;

namespace WebTaxiCompany.Pages.Calls
{
    public class CreateModel : PageModel
    {
        private readonly WebTaxiCompany.Data.TaxiCompanyContext _context;

        public CreateModel(WebTaxiCompany.Data.TaxiCompanyContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AddServiceKey"] = new SelectList(_context.AddService, "AddServiceKey", "Description");
        ViewData["CarKey"] = new SelectList(_context.Car, "CarKey", "SpecialMarks");
        ViewData["EmployeeKey"] = new SelectList(_context.Employee, "EmployeeKey", "Address");
        ViewData["RateKey"] = new SelectList(_context.Rate, "RateKey", "Description");
            return Page();
        }

        [BindProperty]
        public Call Call { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Call.Add(Call);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
