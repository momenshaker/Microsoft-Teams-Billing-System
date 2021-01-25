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
        public List<country> _country { get; set; }
        public void OnGet(string id)
        {
            _country = _context.country.ToList();

        }
    }
}