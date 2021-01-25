using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BillingPortal.Pages.Servers
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
        public CompnayServerModel _Servers { get; set; }
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            _Servers._CompnayServerModel = await _context.CompanyServers.FindAsync(id);
            _Servers._Locations = _context.country.ToList();
            if (_Servers._CompnayServerModel == null)
            {
                return RedirectToPage("/Servers/Index");
            }

            return Page();
        }
        public async Task<IActionResult> OnPostAsync(Guid id)
        {

            if (!ModelState.IsValid)
            {

                return Page();
            }
            _context.Entry(_Servers._CompnayServerModel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("/Servers/Index");
        }
    }
}