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
        public CompnayServerModel _Servers { get; set; }
        public IActionResult OnGet()
        {
            _Servers = new CompnayServerModel();
            _Servers._Locations = _context.country.ToList();
            if (_Servers == null)
            {
                return RedirectToPage("/Servers/Index");
            }

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {

                return Page();
            }

            _Servers._CompnayServerModel.id = Guid.NewGuid();
            _context.CompanyServers.Add(_Servers._CompnayServerModel);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Servers/Index");
        }
    }
}