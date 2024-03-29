﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BillingPortal.Models
{
    public class DatabaseContext : DbContext
    {

        public DbSet<RecordsTable> recordsTables { get; set; }
        public DbSet<country> country { get; set; }
        public DbSet<SubPhones> SubPhones { get; set; }
        public DbSet<CompanyServers> CompanyServers { get; set; }
        public DbSet<ExportedFiles> ExportedFiles { get; set; }
        public DbSet<SystemSetting> SystemSettings{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlite("Data Source=" + Path.Combine(@"E:\DB\IVRDATA3.db"));
    }
}
