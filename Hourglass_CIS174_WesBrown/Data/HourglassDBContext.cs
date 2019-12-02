using Hourglass_CIS174_WesBrown.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hourglass_CIS174_WesBrown.Data
{
    public class HourglassDBContext : DbContext
    {
        public HourglassDBContext(DbContextOptions<HourglassDBContext> options) : base (options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<PtoRequest> PtoRequests { get; set; }
        public DbSet<WeeklyHours> WeeklyHours { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
    }
}
