using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebTaxiCompany.Data;
using WebTaxiCompany.Models;

namespace WebTaxiCompany.Pages.AddServices
{
    public class DetailsModel : PageModel
    {
        private readonly WebTaxiCompany.Data.TaxiCompanyContext _context;

        public DetailsModel(WebTaxiCompany.Data.TaxiCompanyContext context)
        {
            _context = context;
        }

        public AddService AddService { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AddService = await _context.AddService.FirstOrDefaultAsync(m => m.AddServiceKey == id);

            if (AddService == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
