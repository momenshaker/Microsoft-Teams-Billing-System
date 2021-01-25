using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BillingPortal.Pages.PhoneProviders
{

    public class EditProviderModel : PageModel
    {
        private readonly ILogger<EditProviderModel> _logger;
        private readonly DatabaseContext _context;

        public EditProviderModel(ILogger<EditProviderModel> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }
        [BindProperty]
        public SubPhonesModel _SubPhones { get; set; }
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            _SubPhones = new SubPhonesModel();
            _SubPhones._SubPhones = await _context.SubPhones.FindAsync(id);
            _SubPhones.CompanyServers = _context.CompanyServers.ToList();
            var GetCountry = _context.country.Find(_SubPhones._SubPhones.CountryID);
            ViewData["Country"] = GetCountry.countryname.Replace(" ", "-");
            if (_SubPhones == null)
            {
                return RedirectToPage("/PhoneProviders/Index", new { id = GetCountry.countryname.Replace(" ", "-") });
            }

            return Page();
        }
        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            var GetCountry = _context.country.Find(_SubPhones._SubPhones.CountryID);
            ViewData["Country"] = GetCountry.countryname.Replace(" ", "-");

            if (!ModelState.IsValid)
            {

                return Page();
            }
            var GetServers = _context.CompanyServers.Find(_SubPhones._SubPhones.Server);
            _SubPhones._SubPhones.ServerName = GetServers.ServerName;
            _context.Entry(_SubPhones._SubPhones).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("/PhoneProviders/Index", new { id = GetCountry.countryname.Replace(" ", "-") });
        }
    }
}