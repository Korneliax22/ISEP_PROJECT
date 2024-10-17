using Microsoft.EntityFrameworkCore;
using ISEP_Project.WebApi.Domain.Entities;

namespace ISEP_Project.WebApi.Infrastructure.Data
{
    public class ISEPDbContext : DbContext
    {
        public ISEPDbContext(DbContextOptions<ISEPDbContext> options)
            : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .HasKey(p => p.MedicalRecordNumber); // Specify the primary key using Fluent API
        }
    }
}
