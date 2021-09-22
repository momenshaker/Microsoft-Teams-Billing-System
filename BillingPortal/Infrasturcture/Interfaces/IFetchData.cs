using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingPortal.Infrasturcture.Interfaces
{
   public interface IFetchData
    {
        Task<string> GetRecordsAsync();
    }
}
