using Microsoft.EntityFrameworkCore;
using mmbm.Core.Models;

namespace mmbm.Persistence
{

    public class MMBMDbContext : DbContext
    {
        public MMBMDbContext(DbContextOptions<MMBMDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConsolidatedReport>()
                .HasOne(a => a.MobileMoneyReport)
                .WithOne(b => b.ConsolidatedReport)
                .HasForeignKey<MobileMoneyReport>(b => b.ConsolidatedReportId);
        }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Simcard> Simcards { get; set; }
        public DbSet<ConsolidatedReport> ConsolidatedReports { get; set; }
        public DbSet<MobileMoneyReport> MobileMoneyReports { get; set; }
    }
}