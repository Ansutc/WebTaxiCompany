using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebTaxiCompany.Data;
using WebTaxiCompany.Models;

namespace WebTaxiCompany.Pages.AddServices
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
            return Page();
        }

        [BindProperty]
        public AddService AddService { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AddService.Add(AddService);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
