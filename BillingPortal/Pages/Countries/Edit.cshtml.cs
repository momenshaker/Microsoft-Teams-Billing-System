using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BillingPortal.Pages.Countries
{
    public class EditModel : PageModel
    {
        private readonly ILogger<EditModel> _logger;
        private readonly DatabaseContext _context;

        public EditModel(ILogger<EditModel> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }
        [BindProperty]
        public country _country { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            _country = await _context.country.FindAsync(id);
            if (_country == null)
            {
                return RedirectToPage("/Countries/Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {

                return Page();
            }


            _context.Entry(_country).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("/Countries/Index");
        }
    }
}