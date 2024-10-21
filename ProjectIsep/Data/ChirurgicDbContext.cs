using System.Collections.Generic;
using ProjectIsep.Model;
using Microsoft.EntityFrameworkCore;

namespace ProjectIsep.Data
{
    public class ChirurgicDbContext : DbContext
    {
        public ChirurgicDbContext(DbContextOptions<ChirurgicDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<OperationRequest> OperationRequests { get; set; }
        public DbSet<OperationType> OperationTypes { get; set; }
        public DbSet<SurgeryRoom> SurgeryRooms { get; set; }

    }
}
