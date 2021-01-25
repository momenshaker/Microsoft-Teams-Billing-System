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
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly DatabaseContext _context;

        public IndexModel(ILogger<IndexModel> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }
        [BindProperty]
        public List<SubPhones> _SubPhones { get; set; }
        public void OnGet(string id)
        {
            var Check = id.Replace("-", " ");
            var GetCountry = _context.country.Where(x => x.countryname == Check).FirstOrDefault();
            ViewData["Country"] = GetCountry.countryname.Replace(" ", "-");
            _SubPhones = _context.SubPhones.Where(x => x.CountryID == GetCountry.id).ToList();

        }
    }
}