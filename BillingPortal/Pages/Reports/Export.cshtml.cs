using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingPortal.ExcelHelpers;
using BillingPortal.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BillingPortal.Pages.Reports
{
    public class ExportModel : PageModel
    {
        private readonly ILogger<ExportModel> _logger;
        private readonly DatabaseContext _context;
        private IHostingEnvironment _environment;

        public ExportModel(ILogger<ExportModel> logger, DatabaseContext context, IHostingEnvironment environment)
        {
            _environment = environment;
            _logger = logger;
            _context = context;
        }
        public IActionResult OnGet(int type, string id)
        {
            WriteExcel _WriteExcel = new WriteExcel(_context, _environment);
            var Item = new ExportedFiles();
            switch (type)
            {
                case 1:
                    var Records = _context.recordsTables.Where(x => x.Phone == true).ToList();
                    if (!string.IsNullOrEmpty(id))
                    {
                        var _RecordsTable = Records.Where(x => id.Any(id => x.CalleeName!= null &&  x.CalleeName.Contains(id)) || id.Any(id => x.CalleeNumber != null &&  x.CalleeNumber.Contains(id))|| id.Any(id => x.CallerName != null && x.CallerName.Contains(id)) || id.Any(id => x.CallerNumber != null && x.CallerNumber.Contains(id))).ToList();
                        Item = _WriteExcel.WriteExcelTable(_RecordsTable, User.Identity.Name);
                    }
                    else
                    {
                        Item = _WriteExcel.WriteExcelTable(Records, User.Identity.Name);

                    }
                    break;

            }
            return File("/ExcelReports/" + Item.FileName, "application /vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                Item.FileName);
        }
    }
}
