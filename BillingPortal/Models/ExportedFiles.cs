using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingPortal.Models
{
    public class ExportedFiles
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public DateTime ExportedOn { get; set; }
        public string ExportedBy { get; set; }
        public string FileName { get; set; }
    }
}
