using BillingPortal.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BillingPortal.ExcelHelpers
{
    public class WriteExcel
    {
        private IHostingEnvironment _environment;
        private readonly DatabaseContext _context;

        public WriteExcel(DatabaseContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public ExportedFiles WriteExcelTable(List<RecordsTable> RecordsTable, string UserID)
        {

            // Lets converts our object data to Datatable for a simplified logic.
            // Datatable is most easy way to deal with complex datatypes for easy reading and formatting.

            DataTable table = (DataTable)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(RecordsTable), (typeof(DataTable)));
            var FileName = Guid.NewGuid().ToString() + ".xlsx";

            var file = Path.Combine(_environment.WebRootPath, "ExcelReports", FileName);
            using (var fs = new FileStream(file, FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook = new XSSFWorkbook();
                ISheet excelSheet = workbook.CreateSheet("Sheet1");

                List<String> columns = new List<string>();
                IRow row = excelSheet.CreateRow(0);
                int columnIndex = 0;

                foreach (System.Data.DataColumn column in table.Columns)
                {
                    columns.Add(column.ColumnName);
                    row.CreateCell(columnIndex).SetCellValue(column.ColumnName);
                    columnIndex++;
                }

                int rowIndex = 1;
                foreach (DataRow dsrow in table.Rows)
                {
                    row = excelSheet.CreateRow(rowIndex);
                    int cellIndex = 0;
                    foreach (String col in columns)
                    {
                        row.CreateCell(cellIndex).SetCellValue(dsrow[col].ToString());
                        cellIndex++;
                    }

                    rowIndex++;
                }
                workbook.Write(fs);
            }
            ExportedFiles exportedFiles = new ExportedFiles()
            {
                ID = Guid.NewGuid(),
                ExportedBy = UserID,
                ExportedOn = DateTime.Now,
                Title = "Report  " + DateTime.Now,
                FileName = FileName
            };
            _context.ExportedFiles.Add(exportedFiles);
            _context.SaveChanges();
            return exportedFiles;
        }
    }
}

