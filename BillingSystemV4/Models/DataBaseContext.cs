using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingSystemV4.Models
{
    public class DatabaseContext : DbContext
    {

        //public DbSet<Records> Records { get; set; }
        public DbSet<RecordsTable> recordsTables { get; set; }
        public DbSet<SubscriptionChecker> SubscriptionChecker { get; set; }
        public DbSet<country> country { get; set; }
        public DbSet<SubPhones> SubPhones { get; set; }
        public DbSet<CompanyServers> CompanyServers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=192.168.1.175;database=BillingTeamsv1.0;User Id=sa;Password=123");
            //optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;database=BillingV1;Trusted_Connection=True;");
        }
    }
}
