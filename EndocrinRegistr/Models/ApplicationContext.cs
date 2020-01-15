using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EndocrinRegistr.Models
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
            
        }

        public DbSet<Diag> Diags { get; set; }
        public DbSet<CaseRecord> CaseRecords { get; set; }
        public DbSet<Doctors> Doctors { get; set; }
        public DbSet<Lab> Labs { get; set; }
        public DbSet<LabCase> LabCases { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<CaseRecord>().Property(p => p.Sex).HasMaxLength(1);
            builder.Entity<CaseRecord>().Property(p => p.DetectCaseY).HasDefaultValueSql("YEAR (GETDATE())");
            builder.Entity<CaseRecord>().Property(p => p.DetectFormationY).HasDefaultValueSql("YEAR (GETDATE())");
            builder.Entity<Doctors>().Property(p => p.Deleted).HasDefaultValue(false);
            builder.Entity<Diag>().Property(p => p.Deleted).HasDefaultValue(false);
            builder.Entity<Lab>().Property(p => p.Deleted).HasDefaultValue(false);
            builder.Entity<LabCase>().Property(p => p.DetectYear).HasDefaultValueSql("YEAR (GETDATE())");
        }
    }
}
