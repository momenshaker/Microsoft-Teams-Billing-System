using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BillingPortal.Pages.Reports
{
    public class OutgoingCallsByUserModel : PageModel
    {
        private readonly ILogger<OutgoingCallsByUserModel> _logger;
        private readonly DatabaseContext _context;

        public OutgoingCallsByUserModel(ILogger<OutgoingCallsByUserModel> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }
        [BindProperty]
        public List<string> _RecordsTable { get; set; }
        public void OnGet(string id)
        {
            _RecordsTable = _context.recordsTables.Where(x => x.Phone == true).Select(x=>x.CallerName).Distinct().ToList();

        }
    }
}