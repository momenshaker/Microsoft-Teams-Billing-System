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
    public class CreateModel : PageModel
    {
        private readonly ILogger<CreateModel> _logger;
        private readonly DatabaseContext _context;

        public CreateModel(ILogger<CreateModel> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }
        [BindProperty]
        public SubPhonesModel _SubPhones { get; set; }
        public async Task<IActionResult> OnGetAsync(string id)
        {
            _SubPhones = new SubPhonesModel();
            _SubPhones.CompanyServers = _context.CompanyServers.ToList();
            var Check = id.Replace("-", " ");
            var GetCountry = _context.country.Where(x => x.countryname == Check).FirstOrDefault();
            ViewData["Country"] = GetCountry.countryname.Replace(" ", "-");
            if (_SubPhones == null)
            {
                return RedirectToPage("/PhoneProviders/Index", new { id = GetCountry.countryname.Replace(" ", "-") });
            }

            return Page();
        }
        public async Task<IActionResult> OnPostAsync(string id)
        {
            var Check = id.Replace("-", " ");
            var GetCountry = _context.country.Where(x => x.countryname == Check).FirstOrDefault();
            ViewData["Country"] = GetCountry.countryname.Replace(" ", "-");

            if (!ModelState.IsValid)
            {

                return Page();
            }
            var GetServers = _context.CompanyServers.Find(_SubPhones._SubPhones.Server);
            _SubPhones._SubPhones.ServerName = GetServers.ServerName;
            _SubPhones._SubPhones.CountryID = GetCountry.id;
            _SubPhones._SubPhones.id = Guid.NewGuid();
            _context.SubPhones.Add(_SubPhones._SubPhones);
            await _context.SaveChangesAsync();

            return RedirectToPage("/PhoneProviders/Index", new { id = id.Replace(" ", "-") });
        }
    }
}