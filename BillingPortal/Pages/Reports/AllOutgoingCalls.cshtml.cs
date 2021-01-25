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
    public class AllOutgoingCallsModel : PageModel
    {
        private readonly ILogger<AllOutgoingCallsModel> _logger;
        private readonly DatabaseContext _context;
        

        public AllOutgoingCallsModel(ILogger<AllOutgoingCallsModel> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }
        [BindProperty]
        public List<RecordsTable> _RecordsTable { get; set; }
        public void OnGet(string id)
        {
            _RecordsTable = _context.recordsTables.Where(x=>x.Phone==true).ToList();

        }
    }
}