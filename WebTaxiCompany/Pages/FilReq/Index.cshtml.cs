using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebTaxiCompany.Pages.FilReq
{
    public class IndexModel : PageModel
    {
        private readonly WebTaxiCompany.Data.TaxiCompanyContext _context;

        public IndexModel(WebTaxiCompany.Data.TaxiCompanyContext context)
        {
            _context = context;
        }
        public List<SelectListItem> Position { get; set; }
        public List<SelectListItem> Rate { get; set; }

        public IActionResult OnGet()
        {
            Position = _context.Position.Select(p =>
                new SelectListItem
                {
                    Value = p.PositionKey.ToString(),
                    Text = p.Name
                }).ToList();

            Rate = _context.Rate.Select(p =>
               new SelectListItem
               {
                   Value = p.RateKey.ToString(),
                   Text = p.Name
               }).ToList();

            return Page();
        }

    }
}